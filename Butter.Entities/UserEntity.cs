namespace Butter.Entities
{
    public class UserEntity
    {
        
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Town { get; set; }

        public string Genre { get; set; }
         
        //Amis
        public ICollection<FriendEntity> MyFriends { get; set; }
        //AmiDe
        public ICollection<FriendEntity> Friends { get; set; }
    }
}