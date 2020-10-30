// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Graph;

// **NOTE** This file was generated by a tool and any changes will be overwritten.


namespace Microsoft.OneDrive.Sdk
{
    /// <summary>
    /// The interface IDriveRequestBuilder.
    /// </summary>
    public partial interface IDriveRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IDriveRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IDriveRequest Request(IEnumerable<Option> options);
    
        /// <summary>
        /// Gets the request builder for Items.
        /// </summary>
        /// <returns>The <see cref="IDriveItemsCollectionRequestBuilder"/>.</returns>
        IDriveItemsCollectionRequestBuilder Items { get; }

        /// <summary>
        /// Gets the request builder for Shared.
        /// </summary>
        /// <returns>The <see cref="IDriveSharedCollectionRequestBuilder"/>.</returns>
        IDriveSharedCollectionRequestBuilder Shared { get; }

        /// <summary>
        /// Gets the request builder for Special.
        /// </summary>
        /// <returns>The <see cref="IDriveSpecialCollectionRequestBuilder"/>.</returns>
        IDriveSpecialCollectionRequestBuilder Special { get; }
    
        /// <summary>
        /// Gets the request builder for DriveRecent.
        /// </summary>
        /// <returns>The <see cref="IDriveRecentRequestBuilder"/>.</returns>
        IDriveRecentRequestBuilder Recent();
    
    }
}
