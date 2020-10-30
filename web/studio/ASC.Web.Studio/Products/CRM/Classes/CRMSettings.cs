/*
 *
 * (c) Copyright Ascensio System Limited 2010-2020
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/


#region Import

using System;
using System.Configuration;
using System.Runtime.Serialization;

using ASC.Core;
using ASC.Core.Common.Settings;
using ASC.CRM.Core;


#endregion

namespace ASC.Web.CRM.Classes
{
    [Serializable]
    [DataContract]
    public class SMTPServerSetting
    {

        public SMTPServerSetting()
        {
            Host = String.Empty;
            Port = 0;
            EnableSSL = false;
            RequiredHostAuthentication = false;
            HostLogin = String.Empty;
            HostPassword = String.Empty;
            SenderDisplayName = String.Empty;
            SenderEmailAddress = String.Empty;
        }

        public SMTPServerSetting(ASC.Core.Configuration.SmtpSettings smtpSettings)
        {
            Host = smtpSettings.Host;
            Port = smtpSettings.Port;
            EnableSSL = smtpSettings.EnableSSL;
            RequiredHostAuthentication = smtpSettings.EnableAuth;
            HostLogin = smtpSettings.CredentialsUserName;
            HostPassword = smtpSettings.CredentialsUserPassword;
            SenderDisplayName = smtpSettings.SenderDisplayName;
            SenderEmailAddress = smtpSettings.SenderAddress;
        }

        [DataMember]
        public String Host { get; set; }

        [DataMember]
        public int Port { get; set; }

        [DataMember]
        public bool EnableSSL { get; set; }

        [DataMember]
        public bool RequiredHostAuthentication { get; set; }

        [DataMember]
        public String HostLogin { get; set; }

        [DataMember]
        public String HostPassword { get; set; }

        [DataMember]
        public String SenderDisplayName { get; set; }

        [DataMember]
        public String SenderEmailAddress { get; set; }

    }

    [Serializable]
    [DataContract]
    public class InvoiceSetting
    {
        public InvoiceSetting()
        {
            Autogenerated = false;
            Prefix = String.Empty;
            Number = String.Empty;
            Terms = String.Empty;
        }

        public static InvoiceSetting DefaultSettings
        {
            get
            {
                return new InvoiceSetting
                {
                    Autogenerated = true,
                    Prefix = ConfigurationManagerExtension.AppSettings["crm.invoice.prefix"] ?? "INV-",
                    Number = "0000001",
                    Terms = String.Empty,
                    CompanyName = String.Empty,
                    CompanyLogoID = 0,
                    CompanyAddress = String.Empty
                };
            }
        }

        [DataMember]
        public bool Autogenerated { get; set; }

        [DataMember]
        public String Prefix { get; set; }

        [DataMember]
        public String Number { get; set; }

        [DataMember]
        public String Terms { get; set; }

        [DataMember]
        public String CompanyName { get; set; }

        [DataMember]
        public Int32 CompanyLogoID { get; set; }

        [DataMember]
        public String CompanyAddress { get; set; }
    }


    [Serializable]
    [DataContract]
    public class CRMSettings : BaseSettings<CRMSettings>
    {
        [DataMember(Name = "DefaultCurrency")]
        private string defaultCurrency;

        //[DataMember]
        public SMTPServerSetting SMTPServerSetting
        {
            get
            {
                return new SMTPServerSetting(CoreContext.Configuration.SmtpSettings);
            }
        }

        [DataMember(Name = "SMTPServerSetting")]
        public SMTPServerSetting SMTPServerSettingOld { get; set; }

        [DataMember]
        public InvoiceSetting InvoiceSetting { get; set; }

        [DataMember]
        public Guid WebFormKey { get; set; }

        public override Guid ID
        {
            get { return new Guid("fdf39b9a-ec96-4eb7-aeab-63f2c608eada"); }
        }

        public CurrencyInfo DefaultCurrency
        {
            get { return CurrencyProvider.Get(defaultCurrency); }
            set { defaultCurrency = value.Abbreviation; }
        }

        [DataMember(Name = "ChangeContactStatusGroupAuto")]
        public string ChangeContactStatusGroupAutoWrapper { get; set; }

        [IgnoreDataMember]
        public Boolean? ChangeContactStatusGroupAuto
        {
            get { return string.IsNullOrEmpty(ChangeContactStatusGroupAutoWrapper) ? null : (bool?)bool.Parse(ChangeContactStatusGroupAutoWrapper); }
            set { ChangeContactStatusGroupAutoWrapper = value.HasValue ? value.Value.ToString().ToLowerInvariant() : null; }
        }

        [DataMember(Name = "AddTagToContactGroupAuto")]
        public string AddTagToContactGroupAutoWrapper { get; set; }

        [IgnoreDataMember]
        public Boolean? AddTagToContactGroupAuto
        {
            get { return string.IsNullOrEmpty(AddTagToContactGroupAutoWrapper) ? null : (bool?)bool.Parse(AddTagToContactGroupAutoWrapper); }
            set { AddTagToContactGroupAutoWrapper = value.HasValue ? value.Value.ToString().ToLowerInvariant() : null; }
        }

        [DataMember(Name = "WriteMailToHistoryAuto")]
        public Boolean WriteMailToHistoryAuto { get; set; }

        [DataMember(Name = "IsConfiguredPortal")]
        public bool IsConfiguredPortal { get; set; }

        [DataMember(Name = "IsConfiguredSmtp")]
        public bool IsConfiguredSmtp { get; set; }

        public override ISettings GetDefault()
        {
            var languageName = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            var findedCurrency = CurrencyProvider.GetAll().Find(item => String.Compare(item.CultureName, languageName, true) == 0);

            return new CRMSettings
            {
                defaultCurrency = findedCurrency != null ? findedCurrency.Abbreviation : "USD",
                IsConfiguredPortal = false,
                ChangeContactStatusGroupAuto = null,
                AddTagToContactGroupAuto = null,
                WriteMailToHistoryAuto = false,
                WebFormKey = Guid.Empty,
                InvoiceSetting = InvoiceSetting.DefaultSettings
            };
        }
    }


    [Serializable]
    [DataContract]
    public class CRMReportSampleSettings : BaseSettings<CRMReportSampleSettings>
    {
        [DataMember(Name = "NeedToGenerate")]
        public bool NeedToGenerate { get; set; }

        public override Guid ID
        {
            get { return new Guid("{54CD64AD-E73B-45A3-89E4-4D42A234D7A3}"); }
        }

        public override ISettings GetDefault()
        {
            return new CRMReportSampleSettings { NeedToGenerate = true };
        }
    }
}