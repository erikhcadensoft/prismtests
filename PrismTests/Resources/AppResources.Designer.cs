﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrismTests.Resources {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("PrismTests.Resources.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string LoadingText {
            get {
                return ResourceManager.GetString("LoadingText", resourceCulture);
            }
        }
        
        internal static string Global_RequiredHelper {
            get {
                return ResourceManager.GetString("Global_RequiredHelper", resourceCulture);
            }
        }
        
        internal static string Global_Button_Close {
            get {
                return ResourceManager.GetString("Global_Button_Close", resourceCulture);
            }
        }
        
        internal static string Global_Button_Back {
            get {
                return ResourceManager.GetString("Global_Button_Back", resourceCulture);
            }
        }
        
        internal static string Global_Button_Cancel {
            get {
                return ResourceManager.GetString("Global_Button_Cancel", resourceCulture);
            }
        }
        
        internal static string Global_Button_Submit {
            get {
                return ResourceManager.GetString("Global_Button_Submit", resourceCulture);
            }
        }
        
        internal static string UserAccount_PageTitle {
            get {
                return ResourceManager.GetString("UserAccount_PageTitle", resourceCulture);
            }
        }
        
        internal static string UserAccounts_PageTitle {
            get {
                return ResourceManager.GetString("UserAccounts_PageTitle", resourceCulture);
            }
        }
        
        internal static string CreateUserAccount_PageTitle {
            get {
                return ResourceManager.GetString("CreateUserAccount_PageTitle", resourceCulture);
            }
        }
    }
}