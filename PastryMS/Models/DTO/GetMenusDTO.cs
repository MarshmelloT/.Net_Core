using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class GetMenusDTO
	{
		public GetMenusDTO() { }
		public GetMenusDTO(List<HomeMenuInfoDTO> menus)
		{
			var HomeMenuInfoDTO = MenuInfo.FirstOrDefault();
			if (HomeMenuInfoDTO != null)
			{
				HomeMenuInfoDTO.Child = menus;
			}
		}
		/// <summary>
		/// Home
		/// </summary>
		public HomeMenuInfoDTO HomeInfo { get; set; } = new HomeMenuInfoDTO()
		{
			Title = "首页",
			Href = "~/layuimini/page/welcome-1.html?t=1",
            Target = "_self",
        };


		/// <summary>
		/// logo
		/// </summary>
		public HomeMenuInfoDTO LogoInfo { get; set; } = new HomeMenuInfoDTO()
		{
			Title = "物资管理系统",
			Image = "~/layuimini/images/logo.png",
            Target = "_self",
            Href = "/Home/Index",
        };

		/// <summary>
		/// 权限菜单树
		/// </summary>
		public List<HomeMenuInfoDTO> MenuInfo { get; set; } = new List<HomeMenuInfoDTO>()
		{
			new HomeMenuInfoDTO()
			{
				Title = "常规管理",
				Icon="fa fa-address-book",
				Href = "",
				Target="_self",
            }
		};
	}
}
