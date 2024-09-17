﻿using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BCASRequireMates.Data
{
    public class AppendVersionTagHelperInitializer: ITagHelperInitializer<ScriptTagHelper>
    {
        public void Initialize(ScriptTagHelper helper, ViewContext context)
        {
            helper.AppendVersion = true;
        }
    }
}
