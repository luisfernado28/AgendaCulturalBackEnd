//-----------------------------------------------------------------------------
// <copyright file="EdmModelBuilder.cs" company=".NET Foundation">
//      Copyright (c) .NET Foundation and Contributors. All rights reserved.
//      See License.txt in the project root for license information.
// </copyright>
//------------------------------------------------------------------------------


using Events.Domain;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Events.API
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Event>("Events");
            builder.EntitySet<User>("Users");

            // unbound
            builder.Action("ResetData");

            return builder.GetEdmModel();
        }
    }
}
