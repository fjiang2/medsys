using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.Serializing.Helpers;
using DevExpress.XtraGrid.Views.Base;


namespace Sys.ViewManager.DevEx
{

    public class XtraGridFilterSerializer : XmlXtraSerializer {

        public static void SaveFilter(ColumnView view, Stream stream) 
        {
            XtraGridFilterSerializer serializer = new XtraGridFilterSerializer();
            serializer.Serialize(stream, serializer.GetFilterProps(view), "View");
        }
    
        public static void LoadFilter(ColumnView view, Stream stream) 
        {
            view.RestoreLayoutFromStream(stream, DevExpress.Utils.OptionsLayoutGrid.FullLayout);
        }

    
        public static void LoadFilter(ColumnView view, string file) 
        {
            view.RestoreLayoutFromXml(file, DevExpress.Utils.OptionsLayoutGrid.FullLayout);
        }

        protected XtraPropertyInfoCollection GetFilterProps(ColumnView view) 
        {
            XtraPropertyInfoCollection store = new XtraPropertyInfoCollection();
            ArrayList propList = new ArrayList();
            
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(view);
            propList.Add(properties.Find("ActiveFilterEnabled", false));
            propList.Add(properties.Find("ActiveFilterString", false));
            propList.Add(properties.Find("MRUFilters", false));
            propList.Add(properties.Find("ActiveFilter", false));

            MethodInfo mi = typeof(SerializeHelper).GetMethod("SerializeProperty", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            (view as IXtraSerializable).OnStartSerializing();
            foreach(PropertyDescriptor prop in propList) 
            {
                mi.Invoke(null, new object[] { store, view, prop, XtraSerializationFlags.None, null });
            }
            
            (view as IXtraSerializable).OnEndSerializing();

            return store;
       }
    }
}
