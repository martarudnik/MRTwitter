﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MRTwitter.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GlobalResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GlobalResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MRTwitter.Resources.GlobalResources", typeof(GlobalResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter some text to search on:.
        /// </summary>
        public static string EnterText {
            get {
                return ResourceManager.GetString("EnterText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to My Tweets.
        /// </summary>
        public static string MyTweets {
            get {
                return ResourceManager.GetString("MyTweets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, but your search did not return any results.
        /// </summary>
        public static string NoResults {
            get {
                return ResourceManager.GetString("NoResults", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search.
        /// </summary>
        public static string Search {
            get {
                return ResourceManager.GetString("Search", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to search phrase....
        /// </summary>
        public static string SearchPhrase {
            get {
                return ResourceManager.GetString("SearchPhrase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A search term should not be more than 25 characters long..
        /// </summary>
        public static string TextLenght25 {
            get {
                return ResourceManager.GetString("TextLenght25", resourceCulture);
            }
        }
    }
}
