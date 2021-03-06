﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Tie;
using System.Reflection;


namespace Sys
{
    public static class Helper
    {

        public static void Start()
        {
            HostType.Register(new Type[]
            {
                typeof(DateTime), 
                typeof(string),
                typeof(System.Reflection.Assembly),
                typeof(Tie.HostType)
            }, true);

            Script.FunctionChain.Add(functions);
            RegisterValizableClass();

            ExceptionLogHelper();
        }


        public static void ExceptionLogHelper()
        {
            bool log1 = Configuration.Instance.GetValue<bool>("logger.textfile");
            bool log2 = Configuration.Instance.GetValue<bool>("logger.mail");

            if (!log1 && !log2)
                return;

            ExceptionLogger logger = new ExceptionLogger();
            logger.NotificationType = NotificationType.Inform;

            if (log1)
            {
                logger.AddLogger(new TextFileLogger());
            }

            if (log2)
            {
                EmailLogger emailLogger = new EmailLogger();
                emailLogger.EmailFrom = Configuration.Instance.GetValue<string>("mail.application");
                emailLogger.EmailTo = Configuration.Instance.GetValue<string>("mail.developer");

                VAL smtp = Configuration.Instance.GetValue("server.smtp");
                emailLogger.EmailServer = (string)smtp["host"];
                emailLogger.Port = (int)smtp["port"];
                emailLogger.EnableSsl = (bool)smtp["ssl"];
                logger.AddLogger(emailLogger);
            }
        }



        private static VAL functions(string func, VAL parameters, Memory DS)
        {
            int size = parameters.Size;
            VAL L0 = size > 0 ? parameters[0] : null;
            VAL L1 = size > 1 ? parameters[1] : null;
            VAL L2 = size > 2 ? parameters[2] : null;

            switch (func)
            {
                //VALUE CAST
                case "char":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.stringcon,Convert.ToChar(L0.Value));
                        return L0;
                    }
                    break;

                case "float":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.doublecon, Convert.ToSingle(L0.Value));
                        return L0;
                    }
                    break;

                case "decimal":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.doublecon, Convert.ToDecimal(L0.Value));
                        return L0;
                    }
                    break;

                case "double":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.doublecon, Convert.ToDouble(L0.Value));
                        return L0;
                    }
                    break;

                case "byte":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.intcon, Convert.ToByte(L0.Value));
                        return L0;
                    }
                    break;

                case "int":
                case "int32":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.intcon, Convert.ToInt32(L0.Value));
                        return L0;
                    }
                    break;

                case "int16":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.intcon, Convert.ToInt16(L0.Value));
                        return L0;
                    }
                    break;

                case "int64":
                    if (size == 1)
                    {
                        L0.UpdateObject(VALTYPE.doublecon, Convert.ToInt64(L0.Value));
                        return L0;
                    }
                    break;

                case "object":
                    if (size == 1 && L0.VALTYPE == VALTYPE.listcon)         //强制变为object[] 数组
                        return VAL.NewHostType(L0.ObjectArray);
                    else
                        break;

                case "lowercase":
                    if (size == 1)
                        return new VAL(L0.ToSimpleString().ToLower());
                    break;
                case "uppercase":
                    if (size == 1)
                        return new VAL(L0.ToSimpleString().ToUpper());
                    break;

                case "substring":
                    if (size == 2 && L0.VALTYPE == VALTYPE.stringcon && L1.VALTYPE == VALTYPE.intcon)
                        return new VAL(L0.ToSimpleString().Substring(L1.Intcon));
                    if (size == 3 && L0.VALTYPE == VALTYPE.stringcon && L1.VALTYPE == VALTYPE.intcon && L2.VALTYPE == VALTYPE.intcon)
                        return new VAL(L0.ToSimpleString().Substring(L1.Intcon, L2.Intcon));
                    break;

                case "Date":
                    if (size == 3)
                        return VAL.Boxing(new DateTime(L0.Intcon, L1.Intcon, L2.Intcon));
                    break;
            }

            return null;
        }




        private static void RegisterValizableClass()
        {

//-------------------------------------------------------------------------------------------------------------------------------------------------------------

            Valizer.Register<Size>(delegate(Size size)
            {
                return new VAL(string.Format("new System.Drawing.Size({0},{1})", size.Width, size.Height));
            });


//-------------------------------------------------------------------------------------------------------------------------------------------------------------

            Valizer.Register<Point>(delegate(Point point)
            {
                return new VAL(string.Format("new {0}({1},{2})", typeof(Point).FullName, point.X, point.Y));
            }
              );


//-------------------------------------------------------------------------------------------------------------------------------------------------------------

            Valizer.Register<Color>(delegate(Color host)
            {
                Color color = (Color)host;

                if (color.Name.Substring(0, 1) != "0" && color.Name.Substring(0, 1) != "f")
                    return new VAL(host.GetType().FullName + '.' + color.Name);

                return new VAL(string.Format("System.Drawing.Color.FromArgb({0},{1},{2})", color.R, color.G, color.B));
            });


//-------------------------------------------------------------------------------------------------------------------------------------------------------------

            //new System.Drawing.Font("MS Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            HostType.Register(typeof(System.Drawing.FontStyle));
            HostType.Register(typeof(System.Drawing.GraphicsUnit));
            Valizer.Register<Font>(@"
                format('new {0}(""{1}"",(float){2},{3},{4},(byte)0)', 
                    this.GetType().FullName, this.Name, this.Size, this.Style.valize(), this.Unit.valize())
            ");



//-------------------------------------------------------------------------------------------------------------------------------------------------------------



#if VERSION2            
      


            HostType.Register(typeof(System.Windows.Forms.TextBox), delegate(object host)
            {
                System.Windows.Forms.TextBox control = (System.Windows.Forms.TextBox)host;

                string p = string.Format("Text:'{1}', ReadOnly:{2}", control.Text, control.ReadOnly);
                return string.Format("(new {0}()).classof({1})", host.GetType().FullName, "{"+p+"}" );
            });
#endif

//-------------------------------------------------------------------------------------------------------------------------------------------------------------


            Valizer.Register<Rectangle>(delegate(Rectangle host)
            {
                Rectangle rect = (Rectangle)host;
                VAL val = VAL.Boxing(new int[] { rect.X, rect.Y, rect.Width, rect.Height });
                return val;
            },
            delegate(VAL val)
            {
                return new Rectangle(val[0].Intcon, val[1].Intcon, val[2].Intcon, val[3].Intcon);
            }
            );


//-------------------------------------------------------------------------------------------------------------------------------------------------------------


            Valizer.Register<Guid>(delegate(Guid host)
            {
                Guid guid = (Guid)host;
                byte[] bytes = guid.ToByteArray();
                return new VAL("\"" + StringExtension.ByteArrayToHexString(bytes) + "\"");     //because this is a string, need quotation marks ""
            },
            delegate(VAL val)
            {
                byte[] bytes = StringExtension.HexStringToByteArray(val.Str);
                return new Guid(bytes);
            }
            );


//-------------------------------------------------------------------------------------------------------------------------------------------------------------

        }





    }
}
