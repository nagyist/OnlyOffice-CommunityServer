// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using Microsoft.Graph;

using Newtonsoft.Json;

// **NOTE** This file was generated by a tool and any changes will be overwritten.


namespace Microsoft.OneDrive.Sdk
{
    /// <summary>
    /// The type File.
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public partial class File
    {
    
        /// <summary>
        /// Gets or sets hashes.
        /// </summary>
        [DataMember(Name = "hashes", EmitDefaultValue = false, IsRequired = false)]
        public Hashes Hashes { get; set; }
    
        /// <summary>
        /// Gets or sets mimeType.
        /// </summary>
        [DataMember(Name = "mimeType", EmitDefaultValue = false, IsRequired = false)]
        public string MimeType { get; set; }
    
        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    
    }
}
