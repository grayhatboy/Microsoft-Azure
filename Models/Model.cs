using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microsoft_Azure.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public Guid Playerid { get; set; }
        public string PlayerName { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public int Level { get; set; }
        public string Email { get; set; }
    }

    [Table("Asset")]
    public class Asset
    {
        [Key]
        public Guid Assetid { get; set; }
        public string AssetName { get; set; }
        public int LevelRequire { get; set; }
    }

    [Table("PlayerAsset")]
    public class PlayerAsset
    {
        [Key, Column(Order = 0)]
        public Guid Playerid { get; set; }
        [Key, Column(Order = 1)]
        public Guid Assetid { get; set; }
    }
}