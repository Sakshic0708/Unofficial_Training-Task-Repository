// Here is my JavaScript function to convert CSV into JSON:
function csvToJson(csv) {
    var NewLine = csv.split("\n");
    var ConvertedJSOnData = [];
    var headingOfChart = NewLine[0].split(",");
    for (var ChartData = 1; ChartData < NewLine.length; ChartData++) {
        var JSONobj = {};
        var currentline = NewLine[ChartData].split(",");
        for (var InnerChartData = 0; InnerChartData < headingOfChart.length; InnerChartData++) {
            JSONobj[headingOfChart[InnerChartData]] = currentline[InnerChartData];
        }
        ConvertedJSOnData.push(JSONobj);
    }
    return ConvertedJSOnData; //Javascript Object
}

function search() {
    let input = document.getElementById("SearchBar").value.toLowerCase();
    let x = document.getElementsByClassName("className");
  
    for (let i = 0; i < x.length; i++) {
      if (!x[i].innerHTML.toLowerCase().includes(input)) {
        x[i].style.display = "none";
      } else {
        x[i].style.display = "";
      }
    }
  }
  

$(document).ready(function () {
    function AllData() {
        $.get('./MasterChartOfAcounts - Sheet1.csv', function (csvMasterChartData) {
            var MasterTableData = csvToJson(csvMasterChartData);

            for (var i = 0; i < MasterTableData.length; i++) {
                var MasterData = MasterTableData[i];
                if (MasterData.Number != "") {
                    $("#MasterDataDiv").append("<div class='MasterInnerDiv small'><i class=' material-icons'>drag_indicator</i>" + " " + MasterData.AccountCode + "--" + MasterData.AccountName + "</div>");
                }
            };
        });
    }
    AllData();
    function SourceAllData(){
        $.get('./Standard_one.csv', function (csvStandardCofA) {
            var StandardCofData = csvToJson(csvStandardCofA);
            for (var i = 0; i < StandardCofData.length; i++) {
                var StandardData = StandardCofData[i];
                    if (StandardData.Number != "") {
                    $("#StandardDataDiv").append("<div class='StandardInnerDiv small d-flex justify-content-between'>" + " " + StandardData.Number + " " + StandardData.Name + "<i class='material-icons icon history'>done_all history</i></div>");

                    $("#MostLikelyDiv").append("<div class='MostLikelyInnerDiv'>" + " " + "</div>");
                    $("#LikelyDiv").append("<div class='LikelyInnerDiv'>" + " " + "</div>");
                    $("#PossibleDiv").append("<div class='PossibleInnerDiv'>" + " " + "</div>");
                    }
                }
            });
            
    }
    SourceAllData();

    $(document).on("click", ".history", function() {
        $("#HistoryModal").modal("show");
    });
    var $links = $('a').click(function () {
        $('a').removeClass('clicked');
        $(this).addClass('clicked');
     });
    // When a radio button is clicked
    $('input[name="AccountTypeName"]').click(function () {
        // Get the value of the selected radio button
        var selectedValue = $(this).attr('data-button-link');
        // Find the corresponding menu item using the same data-button-link attribute
        var menuItem = $('.menu a[data-button-link="' + selectedValue + '"]');
        // Simulate a click on the corresponding menu item
        menuItem.click();
    });

    
    // Navbar ScrollBar <> SVG
    $('#btn-nav-previous').click(function () {
        $(".menu-inner-box").animate({ scrollLeft: "-=100px" });
    });
    $('#btn-nav-next').click(function () {
        $(".menu-inner-box").animate({ scrollLeft: "+=100px" });
    });
    // Navbar Li Click Event Particular Data Call
    $('.menu-item').click(function () {

        var ValueOfNav = $(this).data("value");
        const NameValueCompare = {
            "Assets": "ASSETS",
            "Liability": "LIABILITIES",
            "Equity/Capital": "EQUITY/CAPITAL",
            "Revenue": "Professional Services Revenue",
            "CoGs": "Product Revenue",
            "Expenses": 'Labor Expense',
            "Other": "Product Costs"
        };
        ComparedData = NameValueCompare[ValueOfNav];
        $("#MasterDataDiv").html('');
        // Read CSV Of MasterChartOfAccounts
        $.get('./MasterChartOfAcounts - Sheet1.csv', function (csvMasterChartData) {
            var MasterTableData = csvToJson(csvMasterChartData);
            for (var i = 0; i < MasterTableData.length; i++) {
                var MasterData = MasterTableData[i];
                if (MasterData.AccountTypeName == ComparedData) {
                    if (MasterData.Number != "") {
                        $("#MasterDataDiv").append("<div class='MasterInnerDiv small'><i class=' material-icons'>drag_indicator</i>" + " " + MasterData.AccountCode + "--" + MasterData.AccountName + "</div>");
                    }
                }
            };
        });
    });
    // All Data Click functionality
    $(document).on("click", "#AllData", function () {
        AllData();
    })
  
    $('.comparedData').click(function () {
        var ButtonValue = $(this).data("button-link");
        const NameValueCompare = {
            "Assets": "Assets",
            "Liability": "Liabilities",
            "Equity/Capital": "Equity",
            "Revenue": "Revenue",
            "CoGs": "COGS",
            "G&A Expenses": "Expense",
            "Other": "Other Rev & Exp"
        };
        var ComparedData1 = NameValueCompare[ButtonValue];

        $("#StandardDataDiv").html('');
        $("#MostLikelyDiv").html('');
        $("#LikelyDiv").html('');
        $("#PossibleDiv").html('');
        // Standard CoFA Read File 
        $.get('./Standard_one.csv', function (csvStandardCofA) {
            var StandardCofData = csvToJson(csvStandardCofA);
            for (var i = 0; i < StandardCofData.length; i++) {
                var StandardData = StandardCofData[i];
                if (StandardData.Type == ComparedData1) {
                    if (StandardData.Number != "") {
                    $("#StandardDataDiv").append("<div class='StandardInnerDiv small d-flex justify-content-between'>" + " " + StandardData.Number + " " + StandardData.Name + "<i class='material-icons icon history'>done_all history</i></div>");

                    $("#MostLikelyDiv").append("<div class='MostLikelyInnerDiv'>" + " " + "</div>");
                    $("#LikelyDiv").append("<div class='LikelyInnerDiv'>" + " " + "</div>");
                    $("#PossibleDiv").append("<div class='PossibleInnerDiv'>" + " " + "</div>");
                }
                }
            }
        });
    });

});
new Sortable(document.getElementById('MostLikelyDiv'), {
    group:{
        name:"shared",
    },
    animation: 100,
    sort: false
  });
  new Sortable(document.getElementById('LikelyDiv'), {
    group:{
        name:"shared",
    },
    animation: 100,
    sort: false
  });
  new Sortable(document.getElementById('PossibleDiv'), {
    group:{
        name:"shared",
    },
    animation: 100,
    sort: false
  });
new Sortable(document.getElementById('MasterDataDiv'), {
    group:{
        name: "shared",
        pull:"clone",
        put:false,
    }, 
    animation: 100,
    sort: false,
  });
  