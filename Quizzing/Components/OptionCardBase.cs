using Microsoft.AspNetCore.Components;
using Quizzing.Models;

namespace Quizzing.Components
{
    public class OptionCardBase : ComponentBase
    {
        [Parameter]
        public Option Option { get; set; } = new Option();
        [Parameter]
        public EventCallback<Option> OnOptionSelected { get; set; }

        protected async void SelectOption()
        {
            await OnOptionSelected.InvokeAsync(Option);
        }
    }
}
