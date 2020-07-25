﻿using System;

namespace Attributes
{
    class AttributeExample
    {
        public static void Usage()
        {
            Type widgetType = typeof(Widget);

            object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);
            if (widgetClassAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
                Console.WriteLine($"Widget class help URL: {attr.Url} - Related topic: {attr.Topic}");
            }

            System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display));
            object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);
            if (displayMethodAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
                Console.WriteLine($"Display method help URL: {attr.Url} - Related topic: {attr.Topic}");
            }
        }
    }

    public class HelpAttribute : Attribute
    {
        string url;
        string topic;

        public HelpAttribute(string url)
        {
            this.url = url;
        }

        public string Url => url;
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
    }

    [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/attributes")]
    public class Widget
    {
        [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/attributes", Topic = "Display")]
        public void Display(string text)
        {

        }
    }



}
