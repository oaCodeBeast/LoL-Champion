using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniLoLProject.DAL
{
    class MetaData
    {
    }

    public class MinLoLChampionMetaData
    {
        [Key]
        public int ChampID { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string Title { get; set; }
       
        public string ChampIcon { get; set; }
       
        public string ChampPic { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string ChampBio { get; set; }
  
 
        [Required(ErrorMessage = "* Required")]
        public int UltimateID { get; set; }
        [Required(ErrorMessage = "* Required")]
        public int ChampRoleID { get; set; }

    }
    [MetadataType(typeof(MinLoLChampionMetaData))]
    public partial class MinLoLChampion { }

    public class MinLoLUltimateMetaData
    {
        [Key]
        public int UltimateID { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string UltimateName { get; set; }
        
        public string UltimateIcon { get; set; }
   
        public string UltimatePic { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string UltimateDescription { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string UltimateCost { get; set; }

    }
    [MetadataType(typeof(MinLoLUltimateMetaData))]
    public partial class MinLoLUltimate {
        public string shortDescription
        {
            get
            {
                if(UltimateDescription.Length > 100)
                {
                    return UltimateDescription.Substring(0, UltimateDescription.IndexOf('.') + 1);
                }
                else
                {
                    return UltimateDescription;
                }
            }
        }
    }

    public class MinLoLRoleMetaData
    {
        [Key]
        public int ChampRoleID { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "* Required")]
        public string RoleDescription { get; set; }

    }
    [MetadataType(typeof(MinLoLRoleMetaData))]
    public partial class MinLoLRole { }
}
