using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaClix.Migrations
{
    /// <inheritdoc />
    public partial class AddingCast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cast",
                value: "[\"https://images.mubicdn.net/images/cast_member/23435/cache-2118-1604949837/image-w856.jpg?size=x200\",\"https://www.filmibeat.com/img/125x160/popcorn/profile_photos/zach-galifianakis-7365.jpg\",\"https://m.media-amazon.com/images/M/MV5BMTk2MDQwODEwNV5BMl5BanBnXkFtZTcwNjc4MTY0NA@@._V1_QL75_UX140_CR0,0,140,140_.jpg\",\"https://images.mubicdn.net/images/cast_member/142648/cache-138129-1463176946/image-w856.jpg?size=x200\",\"https://images.mubicdn.net/images/cast_member/17568/cache-2872-1529943032/image-w856.jpg?size=x200\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cast",
                value: "[\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQuvmLbWaZ-xW8yh-x0U7LwzvfqgwfZt22zFaIezT7g0dbzFYBh\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTNAEmQ4iK04-aD9qQDmi40q0mf1KHIBrE3RtFcV6mEsGiD-u1y\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTJHjJ4osLEe4jR2eHITThivqrtqDNmB1FsuJR-GUIAXbQ9zPLx\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSDcwaGtfKmtIrkeIQRheUgEtwVLUQF6dIcxIvzH3TYrCpTHIdX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQKo_O-ODw98iHQpsoKwFKdrG2wevekPUEHP0LOs9LRTzy2NuDZ\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Cast",
                value: "[\"https://m.media-amazon.com/images/M/MV5BZGIzOTdmYTUtN2MwYy00OTYwLWI2NjItMGM5NWI4OWNkMTg4XkEyXkFqcGdeQXVyMTExNDQ2MTI@._V1_UY218_CR5,0,150,218_AL_.jpg\",\"http://t1.gstatic.com/images?q=tbn:ANd9GcTyKrKh94n5QjVouHveNZH0roOu1_pI-jC9mxSivBsnchM_F6Ei\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTXOWFjoXRVQun-tC6BlnUfp1KunpehDrBZTmva3nGku3xrQHYX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSC-iura0AinWWuFC4sp49hlYzUWI4ctdmHIHomErlgTMN5w8Mw\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQca59lIsX6cXLNmRMle2fcCkURB4AvtkSqh-4Do1NwxEW49fNW\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Tom_Hardy_by_Gage_Skidmore.jpg/220px-Tom_Hardy_by_Gage_Skidmore.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Charlize-theron-IMG_6045.jpg/220px-Charlize-theron-IMG_6045.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Nicholas_Hoult_%28cropped%29.jpg/220px-Nicholas_Hoult_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg/220px-Hugh_Keays-Byrne_2019_%2832175116127%29_cropped.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg/220px-Paris_Motor_Show_2014_-_Land_Rover_Discovery_Sport_23_%28cropped%29.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Andrew_Stanton_cropped_2009.jpg/170px-Andrew_Stanton_cropped_2009.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/WilliamHMacyTIFFSept2012.jpg/220px-WilliamHMacyTIFFSept2012.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Cast",
                value: "[\"https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-092.jpg?w=800\\u0026h=450\\u0026%23038\",\"https://www.usmagazine.com/wp-content/uploads/2022/11/The-Notebook-Cast-Where-Are-They-Now-093.jpg?w=800\\u0026h=450\\u0026%23038\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTFi8UWJJY_7vRK0B29nu4A6KPSh6hsbgEdw2A9qoeqEvGuRHzA\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Cast",
                value: "[\"https://www.tvguide.com/a/img/resize/2c1921bd0ebb271d24931221c0ce84d8a687fdcb/catalog/provider/10/9/10-57BF562A-9A70-446C-BDF9-60EA03E2E134.png?auto=webp\\u0026fit=crop\\u0026height=300\\u0026width=200\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSxye5wGz9yi6Tvf9eGAVaKQ5i3nig1jkT6nr6Xnmsbv1m4wWzo\",\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSihAHL5QZPjNaY30jHKtQZ6vcR4Sa9ADoCHDkuegFGzZdEHE3J\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Cast",
                value: "[\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTf0LAQomIIFCVZFKqw_TL-RU9JV9gVDjQqXIwhxX3nN323p7eV\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQgh99SZ6l0oke8eowhJLpD-w5akig37_VZHmc8ABRbHtKfpzNH\",\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSPPSNwqmUCy3XYiToF8hjcx0a7kWJgqM0O7NqOdomF_I1w7czk\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Cast",
                value: "[\"https://images.mubicdn.net/images/cast_member/3493/cache-2153-1604741724/image-w856.jpg?size=x200\",\"https://www.tvguide.com/a/img/resize/7fe387a9c54f619918d93d9062870d65ef58e321/catalog/provider/10/9/10-40D59F1A-AC58-47FC-AF2B-03F6158ABC05.png?auto=webp\\u0026fit=crop\\u0026height=300\\u0026width=200\",\"https://televisionstats.com/_next/image?url=https%3A%2F%2Fimage.tmdb.org%2Ft%2Fp%2Fw154%2Fafs4PCiwn8LR93a10drULLVeVLo.jpg\\u0026w=384\\u0026q=75\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg/220px-Mark_Ruffalo_%2836201774756%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Ben_Kingsley_by_Gage_Skidmore.jpg/220px-Ben_Kingsley_by_Gage_Skidmore.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Leonardo_Dicaprio_Cannes_2019.jpg/220px-Leonardo_Dicaprio_Cannes_2019.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ken_Watanabe_2007_%28cropped%29.jpg/220px-Ken_Watanabe_2007_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg/220px-Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Christian_Bale-7837.jpg/220px-Christian_Bale-7837.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg/220px-Michael_Caine_-_Viennale_2012_a_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Heath_Ledger_%282%29.jpg/220px-Heath_Ledger_%282%29.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Cast",
                value: "[\"https://ew.com/thmb/76cUn_VoM7Yg2AYRTBHcVYUV7C4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/BD-Wong-Jurassic-Park-060823-e0c520031edc45f2b0034b6e2b6efa77.jpg\",\"https://ew.com/thmb/FKzAwWQX_bKGe0MRxnDlb-hvMRE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Bob-Peck-Jurassic-Park-060823-72b6ddac4cd2471fab7f3d885cb53a0a.jpg\",\"https://m.media-amazon.com/images/M/MV5BYjk4MTBkYzEtZmZhYi00ZGFkLWJmYmYtOGRiY2IwYTNhMWFlXkEyXkFqcGdeQXVyMjQ0MTg4Nw@@._V1_UY256_CR16,0,172,256_AL_.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Cast",
                value: "[\"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRdNAmgAHv3IEcUH06lxWJhWDbqaVMV--dBylaJbgMnuBbojtEX\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcThZehyH9DPF1WJLxA2-DT_0SKny_sSJubllj0tl8A5uc2bN_Pd\",\"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQ3Nk_FmLzJ5RhBkaanb4sJdQdbYzcAQj88Idvib7e0i5y87w8W\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Cast",
                value: "[\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbIFJCE30YRbo9jTfUNgZW3imhRpIW6CJwJ0da6xnKiRgelgLq\",\"https://m.media-amazon.com/images/M/MV5BNDE1NGY4ODAtODMxMS00YjU2LTk3ZWItMDFkNDAzOWJhZDE0XkEyXkFqcGdeQXVyNTgzMzk4NDQ@._V1_.jpg\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSj5cZr--Yueur5d8Ld8xNh3xTsifPisbfldVGtdlPVztT0OA6S\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Cast",
                value: "[\"https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg/220px-Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%2846806576944%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg/220px-National_Memorial_Day_Concert_2017_%2834117818524%29_%28cropped%29.jpg\",\"https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Carrie-Anne_Moss_May_2016.jpg/220px-Carrie-Anne_Moss_May_2016.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Cast",
                value: "[\"https://people.com/thmb/ea5JdZLLGgLQbTqZCUH3B15bCtk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/marlon-brando-the-godfather-ca5cfb9768c54e6090dfbc144547b5b9.jpg\",\"https://people.com/thmb/CPTln9aPH7r8ULrglsjBPPjshh4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/robert-duvall-the-godfather-de08805e3d5947d69036b65768107e32.jpg\",\"https://people.com/thmb/P2SKkDNL7Z0z6KtUITUA3riQO_0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(999x0:1001x2)/al-pacino-the-godfather-33d1309ed2c745ac9c3ca7562f96df8b.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "Cast",
                value: "[\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQJBntbqy_AhBhpkcGci8VP79LSwcheGgaj4BEeWLy9pUK3KOy7\",\"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQvYLIEzqWSEciLkKfUNyccomlEM7LC-xsVHO8VNGg8KuauyVFE\",\"https://m.media-amazon.com/images/M/MV5BMjI1NDQwMDA5N15BMl5BanBnXkFtZTgwMDI2OTQ1NDM@._V1_UY256_CR106,0,172,256_AL_.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Cast",
                value: "[\"https://people.com/thmb/U1tEKq-06zEfiYjNrZdWbUnaM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-bruce-willis-22e31b70c39c472f93909220aa87f9ab.jpg\",\"https://pagesix.com/wp-content/uploads/sites/3/2019/10/amanda-plummer-pulp-fiction.jpg?quality=80\\u0026strip=all\\u0026w=878\",\"https://people.com/thmb/3EBJt_w7BTArTCRvZcTWwJ_7la8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(599x0:601x2)/pulp-fiction-tim-roth-418bfec481234c3c9b4583101fcb6781.jpg\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Movies");
        }
    }
}
