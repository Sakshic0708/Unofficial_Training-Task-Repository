// Here is my JavaScript function to convert CSV into JSON:
function csvToJson(csv)
{
    var NewLine=csv.split("\n");
    var ConvertedJSOnData = [];
    var headingOfChart=NewLine[0].split(",");
    for(var ChartData=1; ChartData<NewLine.length; ChartData++)
    {
        var JSONobj = {};
        var currentline=NewLine[ChartData].split(",");
        for(var InnerChartData=0; InnerChartData<headingOfChart.length; InnerChartData++)
        {
            JSONobj[headingOfChart[InnerChartData]] = currentline[InnerChartData];
        }
        ConvertedJSOnData.push(JSONobj);
    }
    return ConvertedJSOnData; //Javascript Object
  }

$(document).ready(function (){
         
    function AllData(){
        $.get('./MasterChartOfAcounts - Sheet1.csv', function(csvMasterChartData) {
            var MasterTableData = csvToJson(csvMasterChartData);
   
        for (var i=0; i < MasterTableData.length; i++){
            var MasterData = MasterTableData[i];
            if(MasterData.Number != ""){
                $("#MasterDataDiv").append("<div class='MasterInnerDiv small d-flex'><i class=' material-icons'>drag_indicator</i>" + " " + MasterData.AccountCode + "--" + MasterData.AccountName + "</div>");
            }
        };
    });
   }
    AllData();
    // Search Bar
     $("#myInput").on("keyup", function(){
        var value = $(this).val().toLowerCase();
        $("#MasterDataDiv *").filter(function() {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
    // Navbar ScrollBar <> SVG
    $('#btn-nav-previous').click(function(){
        $(".menu-inner-box").animate({scrollLeft: "-=100px"});
    }); 
    $('#btn-nav-next').click(function(){
        $(".menu-inner-box").animate({scrollLeft: "+=100px"});
    });
    // Navbar Li Click Event Particular Data Call
        $('.menu-item').click(function (){
            var ValueOfNav = $(this).data("value");
            const NameValueCompare = {
                "Assets":"ASSETS",
                "Liability":"LIABILITIES",
                "Equity/Capital":"EQUITY/CAPITAL",
                "Revenue":"Professional Services Revenue",
                "CoGs":"Product Revenue",
                "Expenses":'Labor Expense',
                "Other":"Product Costs"
            };
            ComparedData = NameValueCompare[ValueOfNav];
            $("#MasterDataDiv").html('');
            // Read CSV Of MasterChartOfAccounts
            $.get('./MasterChartOfAcounts - Sheet1.csv', function(csvMasterChartData) {
            var MasterTableData = csvToJson(csvMasterChartData);
            // console.log(MasterTableData);

            for (var i=0; i < MasterTableData.length; i++){
                var MasterData = MasterTableData[i];
                if(MasterData.AccountTypeName == ComparedData){
                    console.log(MasterData.AccountName);
                    if(MasterData.Number != "")
                    {
                        $("#MasterDataDiv").append("<div class='MasterInnerDiv small d-flex'><i class=' material-icons'>drag_indicator</i>" + " " + MasterData.AccountCode + "--" + MasterData.AccountName + "</div>");
                    }
                }
            };
        });
    });
    // All Data Click functionality
     $(document).on("click","#AllData",function(){
        AllData();
     })
         
    
    // Standard CoFA Read File 
    $.get('./Standard CofA.csv', function(csvStandardCofA) {
        var StandardCofData = csvToJson(csvStandardCofA);
        // console.log(StandardCofData);
        for (var i=0; i < StandardCofData.length; i++)
        {
            var StandardData = StandardCofData[i];

            $("#StandardDataDiv").append("<div class='StandardInnerDiv small d-flex justify-content-between'>" + " " + StandardData.Number + " " + StandardData.Name + "<i class='material-icons icon'>done_all history</i></div>");

            $("#MostLikelyDiv").append("<div class='MostLikelyInnerDiv'>"+ " "+"</div>")

            $("#LikelyDiv").append("<div class='LikelyInnerDiv'>"+ " "+"</div>")

            $("#PossibleDiv").append("<div class='PossibleInnerDiv'>"+ " "+"</div>")
        }
    });
});

