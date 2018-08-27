using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "mail-format")]
    public class MailTagHelper : TagHelper
    {
        private IHostingEnvironment environment;
        public MailTagHelper(IHostingEnvironment env)
        {
            environment = env;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2");
            var Container = new TagBuilder("div");
            var image = new TagBuilder("image");
            image.Attributes["src"] = "/images/test.jpg";
            image.Attributes["width"] = "600";
            Container.InnerHtml.AppendHtml(image);
            var title = new TagBuilder("h3");
            title.InnerHtml.Append("This is the title of the mail");
            title.Attributes["class"] = "text-center";

            var paragraph = new TagBuilder("p");
            var button = new TagBuilder("button");
            button.InnerHtml.Append("Submit My Entry");
            button.Attributes["class"] = "btn btn-primary btn-block text-center";
            paragraph.InnerHtml.AppendHtml(@"
                Don't miss out on your chance to enter our 
                contest “Design a pair of soccer shoes for your favorite player” 
                and participate to win up to $1,000 USD in prizes. 
                Get your entries in soon, you have until 10 AM 
                EST July 10th, 2018 to submit your design.
            ");
            paragraph.Attributes["class"] = "lead";
            
            var content = new TagBuilder("div");
            content.Attributes["class"] = "new-width";
            content.InnerHtml.AppendHtml(title);
            content.InnerHtml.AppendHtml(paragraph);


            content.InnerHtml.AppendHtml(button);

            Container.InnerHtml.AppendHtml(content);

            ///
            output.Content.SetHtmlContent(Container);
        }
    }
}
