using BootstrapBlazor.Components;
using BootstrapBlazorApp.Shared.Auth;
using BootstrapBlazorApp.Shared.Model.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazorApp.Shared.Pages
{
    public partial class Login
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] public MessageService MsgSvr { get; set; }
        [Inject] public AuthenticationStateProvider AuthProvider { get; set; }

        LoginDto model = new LoginDto();
        bool isLoading;

        async void OnLogin()
        {
            isLoading = true;

            var httpResponse = await Http.PostAsJsonAsync<LoginDto>($"api/Auth/Login", model);
            UserDto result = await httpResponse.Content.ReadFromJsonAsync<UserDto>();

            if (string.IsNullOrWhiteSpace(result?.Token) == false)
            {
               // MsgSvr.Success($"登录成功");
                ((AuthProvider)AuthProvider).MarkUserAsAuthenticated(result);
            }
            else
            {
               // MsgSvr.Error($"用户名或密码错误");
            }
            isLoading = false;
            InvokeAsync(StateHasChanged);
        }
    }

}
