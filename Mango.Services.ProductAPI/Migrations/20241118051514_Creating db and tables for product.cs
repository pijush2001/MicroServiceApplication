using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class Creatingdbandtablesforproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://www.google.com/imgres?q=url%20for%20samosa&imgurl=https%3A%2F%2Fimg.pikbest.com%2Forigin%2F05%2F98%2F06%2F93FpIkbEsTb3j.jpg!w700wp&imgrefurl=https%3A%2F%2Fpikbest.com%2Ftemplates%2Ffood-menu-and-restaurant-samosa-social-media-post-banner-template_5980693.html&docid=UaJxoPaaRnuR4M&tbnid=J0ZjQHdIOcsLhM&vet=12ahUKEwiViputh-WJAxUAoa8BHbt9B6EQM3oFCIABEAA..i&w=700&h=700&hcb=2&ved=2ahUKEwiViputh-WJAxUAoa8BHbt9B6EQM3oFCIABEAA", "Samosa", 15.0 },
                    { 2, "Appetizer", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://www.google.com/imgres?q=paneer%20tikka&imgurl=https%3A%2F%2Fwww.indianveggiedelight.com%2Fwp-content%2Fuploads%2F2021%2F08%2Fair-fryer-paneer-tikka-featured.jpg&imgrefurl=https%3A%2F%2Fwww.indianveggiedelight.com%2Fpaneer-tikka%2F&docid=NTMwZjoR2GPmJM&tbnid=iwWrljsVrAS2gM&vet=12ahUKEwie9Zi_h-WJAxUoaPUHHYFWMMoQM3oECGEQAA..i&w=1200&h=1200&hcb=2&ved=2ahUKEwie9Zi_h-WJAxUoaPUHHYFWMMoQM3oECGEQAA", "Paneer Tikka", 13.99 },
                    { 3, "Dessert", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://www.google.com/imgres?q=sweet%20pie&imgurl=https%3A%2F%2Fstordfkenticomedia.blob.core.windows.net%2Fdf-us%2Frms%2Fmedia%2Frecipesmedia%2Frecipes%2Fretail%2Fx17%2F1995%2Fapr%2F18601-homemade-sweet-potato-pie-600x600.jpg%3Fext%3D.jpg&imgrefurl=https%3A%2F%2Fwww.landolakes.com%2Frecipe%2F8071%2Fhomemade-sweet-potato-pie%2F&docid=ZkHRDqX7XD9PiM&tbnid=lJ2ppexzFuvGoM&vet=12ahUKEwj7v4HLh-WJAxWAjq8BHY85J1EQM3oECGEQAA..i&w=600&h=600&hcb=2&ved=2ahUKEwj7v4HLh-WJAxWAjq8BHY85J1EQM3oECGEQAA", "Sweet Pie", 10.99 },
                    { 4, "Entree", "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://www.google.com/imgres?q=pav%20bhaji&imgurl=https%3A%2F%2Fshwetainthekitchen.com%2Fwp-content%2Fuploads%2F2022%2F07%2FPav-bhaji.jpg&imgrefurl=https%3A%2F%2Fshwetainthekitchen.com%2Fpav-bhaji%2F&docid=t_DIFcZjjxM3lM&tbnid=D9zl5B6pfC2JvM&vet=12ahUKEwjR4PjZh-WJAxXmQ_UHHdySOTYQM3oECBsQAA..i&w=1200&h=1800&hcb=2&ved=2ahUKEwjR4PjZh-WJAxXmQ_UHHdySOTYQM3oECBsQAA", "Pav Bhaji", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
