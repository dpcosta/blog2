namespace BlogTeste2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddInfoPublicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Publicado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "DataPublicacao", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DataPublicacao");
            DropColumn("dbo.Posts", "Publicado");
        }
    }
}
