using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.BusinessRules;

namespace Sys.ViewManager.Forms
{
    public static class ValidateExtensions
    {
        
        #region Utility Methods, event handler conversion

        private static ValidationHandler TextRequiredHandler(string message)
        {
            ValidationHandler handler = delegate(Validator validator, object sender)
            {
                Control t = (Control)sender;
                if (t.Text.Trim() == "")
                    validator.error(message);
            };
            return handler;
        }

        private static ValidationEventHandler ToEventHandler(ValidationHandler handler)
        {
            return delegate(Validator validator, object sender, EventArgs e)
            {
                handler(validator, sender);
            };
        }

        private static ValidationHandler ToHandler(ValidationEventHandler handler)
        {
            return delegate(Validator validator, object sender)
            {
                handler(validator, sender, new EventArgs());
            };
        }

        #endregion


        /// <summary>
        /// Validate control during event "Validated" fired, 
        /// notice this Validate will be used twice. 
        ///     1. Event Validated" fired
        ///     2. ValidateProvider.Validate() invoked, empty EventArgs is passed in. see example
        /// </summary>
        /// <param name="control"></param>
        /// <param name="provider"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Validator Validate(this Control control, ValidateProvider provider, ValidationEventHandler handler)
        {
            /*
              Example:
             this.partNotInGP.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
             {
                 if (this.chkNotInGP.Checked && partNotInGP.Text == "")
                      validator.error("Please input Part#");
             
                 if(e.GetType() != typeof(EventArgs))
                 {
                    .....      
                 }
             });
             */
            return provider.Add(control, "Validated", handler).Add(ToHandler(handler));
        }


        /// <summary>
        /// Validate control when ValidateProvider.Passed invoked
        /// </summary>
        /// <param name="control"></param>
        /// <param name="provider"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Validator Validate(this Control control, ValidateProvider provider, ValidationHandler handler)
        {
            return provider.Add(control, handler);
        }


        /// <summary>
        /// Validate TextBox druing event "Validated" and "TextChanged" fired and ValidateProvider.Validate() invoked
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="provider"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Validator Validate(this TextBox textBox, ValidateProvider provider, ValidationEventHandler handler)
        {
            return provider
                .Add(textBox, "TextChanged", handler)
                .Add("Validated", handler)
                .Add(ToHandler(handler));  

        }

       

        /// <summary>
        /// Validate Control.Text==""?  during event fired and ValidateProvider.Validate() invoked
        /// </summary>
        /// <param name="control"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static Validator Required(this Control control, ValidateProvider provider)
        {
            return Required(control, provider, "Required Field.");
        }

        /// <summary>
        ///  Validate Control.Text==""?  during event "Validated" fired and ValidateProvider.Validate() invoked, and show message when invalid
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="provider"></param>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static Validator Required(this Control control, ValidateProvider provider, string message)
        {
            //generate control.Text="" event handler
            ValidationHandler handler = TextRequiredHandler(message);

            return provider
                .Add(control, "Validated", ToEventHandler(handler))
                .Add(handler);

        }
    }
}
