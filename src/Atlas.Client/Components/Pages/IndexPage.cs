﻿using System.Threading.Tasks;

namespace Atlas.Client.Components.Pages
{
    public abstract class IndexPage : PageBase
    {
        public bool DisplayForums { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            DisplayForums = true;
        }
    }
}