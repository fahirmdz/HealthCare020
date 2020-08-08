﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthCare020.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SharedResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SharedResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HealthCare020.Core.Resources.SharedResources", typeof(SharedResources).Assembly);
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
        ///   Looks up a localized string similar to Adresa.
        /// </summary>
        public static string Address {
            get {
                return ResourceManager.GetString("Address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Grad.
        /// </summary>
        public static string City {
            get {
                return ResourceManager.GetString("City", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-mail adresa.
        /// </summary>
        public static string EmailAddress {
            get {
                return ResourceManager.GetString("EmailAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ime.
        /// </summary>
        public static string FirstName {
            get {
                return ResourceManager.GetString("FirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Datum mora biti u budućnosti.
        /// </summary>
        public static string FutureDateTimeConstraintMessage {
            get {
                return ResourceManager.GetString("FutureDateTimeConstraintMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pol.
        /// </summary>
        public static string Gender {
            get {
                return ResourceManager.GetString("Gender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Neispravan format pola. Trebao bi biti &apos;M&apos; ili &apos;Z&apos;.
        /// </summary>
        public static string InvalidGenderFormatMessage {
            get {
                return ResourceManager.GetString("InvalidGenderFormatMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prezime.
        /// </summary>
        public static string LastName {
            get {
                return ResourceManager.GetString("LastName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Broj telefona.
        /// </summary>
        public static string PhoneNumber {
            get {
                return ResourceManager.GetString("PhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Profilna slika.
        /// </summary>
        public static string ProfilePicture {
            get {
                return ResourceManager.GetString("ProfilePicture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Morate odabrati #.
        /// </summary>
        public static string RequiredPickMessage {
            get {
                return ResourceManager.GetString("RequiredPickMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to # je obavezno polje.
        /// </summary>
        public static string RequiredReplacementValidationError {
            get {
                return ResourceManager.GetString("RequiredReplacementValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Obavezno polje.
        /// </summary>
        public static string RequiredValidationError {
            get {
                return ResourceManager.GetString("RequiredValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to # # nije pronađen/a.
        /// </summary>
        public static string ResourceNotFoundValidationMessage {
            get {
                return ResourceManager.GetString("ResourceNotFoundValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Polje može sadržati između # i # karaktera.
        /// </summary>
        public static string StringLengthValidationErrorMask {
            get {
                return ResourceManager.GetString("StringLengthValidationErrorMask", resourceCulture);
            }
        }
    }
}
