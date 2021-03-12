#pragma checksum "C:\Users\samio\source\repos\KBS_Proje\KBS_Proje\Views\HeatTreatment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1e6a626bde7f771bca76700b032b27cf6007914"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HeatTreatment_Index), @"mvc.1.0.view", @"/Views/HeatTreatment/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\samio\source\repos\KBS_Proje\KBS_Proje\Views\_ViewImports.cshtml"
using KBS_Proje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\samio\source\repos\KBS_Proje\KBS_Proje\Views\_ViewImports.cshtml"
using KBS_Proje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1e6a626bde7f771bca76700b032b27cf6007914", @"/Views/HeatTreatment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe713125683b30fc68d3f7b30758456881a70fda", @"/Views/_ViewImports.cshtml")]
    public class Views_HeatTreatment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\samio\source\repos\KBS_Proje\KBS_Proje\Views\HeatTreatment\Index.cshtml"
  
    ViewData["Title"] = "Isıl İşlem Grafik";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""top"" style=""display: flex;"">
	<div id=""grafikler"" >
		<div style=""margin: 10px 0"">
			<a href=""javascript:void(0)"" class=""btn btn-xs btn-primary""  onclick=""insert_grfk()"">Grafik Ekle</a>
		</div>
		<table id=""grd_grfk""></table>
	</div>
	
	<div id=""noktalar"" style=""margin-left: 20px;"">
		<div style=""margin:10px 0"">
			<a href=""javascript:void(0)"" class=""btn btn-xs btn-primary"" onclick=""insert_nkt()"">Nokta Ekle</a>
		</div>
		<table id=""grd_nkt""></table>
	</div>
	
</div>

	<div id=""okuyucular"" style="" float: left;"">
		<div style=""margin:10px 0"">
			<a href=""javascript:void(0)"" class=""btn btn-xs btn-primary"" onclick=""insert_okyc()"">Okuyucu Ekle</a>
		</div>
		<table id=""grd_okyc""></table>
	</div>

<!--------------------------------- chart ------------------------------>
	<div style=""width:900px; display:inline-block; margin-left:70px; margin-top:10px;"">
		<div id=""exp-jpg"" style=""margin-left:60px; display: none;"">
			<a id=""download"" href=""javascript:void(0)"" class=""btn btn-xs");
            WriteLiteral(" btn-primary\">JPEG OLUŞTUR</a>\r\n\t\t</div>\r\n\t\t<div id=graph-container>\r\n\t\t<canvas id=\"chart1\" style=\"margin-top: 10px;\"></canvas>\r\n\t\t</div>\r\n\t</div>\r\n<!--------------------------------------- chart   --------------------------------- -->\r\n\t\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

<script>
	  
$(function(){
	$('#grd_grfk').datagrid({
		title:'GRAFİKLER',
		iconCls:'icon-edit',
		width:620,
		height:270,
		singleSelect:true,
		idField:'id',
		url:'https://localhost:5001/Grafik/GetGrafik',
		method:'get',
		columns:[[
			/*{field:'id',title:'Grafik ID',width:70,align:'left'},*/
			{field:'grafikadi',title:'Grafik Adı',width:190,align:'center',editor:'textbox'},
			{field:'zamanaralik',title:'Zaman Aralığı',width:110,align:'center',editor:'timespinner',
				formatter: function(value,row,index){
					return value.hours + ':' + value.minutes;
				}
			},
			{field:'baslama',title:'başlama zamanı',width:200,align:'center',editor:'datetimebox'},
			{field:'action',title:'Action',width:110,align:'center',
				formatter:function(value,row,index){
					if (row.editing){
						var s = '<a href=""javascript:void(0)"" onclick=""saverow_grfk(this)"">Save</a> ';
						var c = '<a href=""javascript:void(0)"" onclick=""cancelrow_grfk(this)"">Cancel</a>';
						return s+c;
					} ");
                WriteLiteral(@"else {
						var e = '<a href=""javascript:void(0)"" onclick=""editrow_grfk(this)"">Edit</a> ';
						var d = '<a href=""javascript:void(0)"" onclick=""deleterow_grfk(this)"">Delete</a>';
						return e+d;
					}
				}
			}
		]],
		onEndEdit:function(index,row,changes){
			var ed = $(this).datagrid('getEditor', {
				index: index,
				field: 'id'
			});
			$('#grd_grfk').datagrid('reload');
			if(changes.grafikadi == """" || changes.zamanaralik == """" || changes.baslama=="""")
				alert(""Boş alanları doldurup baştan değişiklik yapınız."");
		},
		onBeforeEdit:function(index,row){
			row.editing = true;
			$(this).datagrid('refreshRow', index);
		},
		onAfterEdit:function(index,row){
			row.editing = false;
			var asd = row.zamanaralik;
			row.zamanaralik = null;
			//////////////////////////
				var xx = JSON.stringify(row);
				$.post('https://localhost:5001/Grafik/UpdateGrafik',{ model:xx, timespan:asd }
					,function(result){
						console.log(result);
					}).fail(function(e){
						cons");
                WriteLiteral(@"ole.log(e);
					}
				);
			///////////////////////////////
			$(document).ready(function () { 
			setTimeout(function () { 
				$('#grd_grfk').datagrid('reload');
			}, 1000); 
			}); 
				
		},
		onCancelEdit:function(index,row){
			row.editing = false;
			$(this).datagrid('refreshRow', index);
		},
		onClickRow: function(index,row){
			var xx = row.id;
			var noktaJson = $.post('https://localhost:5001/Nokta/GetNoktaById',{ grafikId:xx }
				,function(result){
					$('#grd_nkt').datagrid('loadData',result);
				}).fail(function(e){
					console.log(e);
				}
			)
		},
		onDblClickRow: function(index,row){
			var xx = row.id;
			var grf_baslama = row.baslama;
			var noktaJson = $.post('https://localhost:5001/Nokta/GetNoktaById',{ grafikId:xx }
				,function(nokta){
					var jqxhrs = $.get( ""https://localhost:5001/Okuyucu/GetOkuyucu"", function(okuyucu) {
							draw(nokta,okuyucu,grf_baslama);
							$('#exp-jpg').show();
						});
				}).fail(function(e){
					console.log(");
                WriteLiteral(@"e);
				}
			)
		}
	}); 

	$('#grd_okyc').datagrid({
		title:'OKUYUCULAR',
		iconCls:'icon-edit',
		width:370,
		height:270,
		singleSelect:true,
		idField:'id',
		url:'https://localhost:5001/Okuyucu/GetOkuyucu',
		method:'get',
		columns:[[
			{field:'grup',title:'Grup',width:60,align:'center',editor:'textbox'},
			{field:'okuyucuadi',title:'Okuyucu Adı',width:90,align:'center',editor:'textbox'},
			{field:'arti',title:'ARTI',width:50,align:'center',editor:'numberbox'},
			{field:'eksi',title:'EKSİ',width:50,align:'center',editor:'numberbox'},
			{field:'action',title:'Action',width:110,align:'center',
				formatter:function(value,row,index){
					if (row.editing){
						var s = '<a href=""javascript:void(0)"" onclick=""saverow_okyc(this)"">Save</a> ';
						var c = '<a href=""javascript:void(0)"" onclick=""cancelrow_okyc(this)"">Cancel</a>';
						return s+c;
					} else {
						var e = '<a href=""javascript:void(0)"" onclick=""editrow_okyc(this)"">Edit</a> ';
						var d = '<a href=""javascr");
                WriteLiteral(@"ipt:void(0)"" onclick=""deleterow_okyc(this)"">Delete</a>';
						return e+d;
					}
				}
			}
		]],
		onEndEdit:function(index,row,changes){
			var ed = $(this).datagrid('getEditor', {
				index: index,
				field: 'id'
			});
			$('#grd_okyc').datagrid('reload');
			if(changes.grup == """" || changes.okuyucuadi == """" || changes.arti=="""" || changes.eksi == """" ){
				alert(""Boş alanları doldurup baştan değişiklik yapınız."");
			}
			if(changes.grup.length > 4 )
				alert(""Grup adı 4 harften kısa olmak zorunda."" );
		},
		onBeforeEdit:function(index,row){
			row.editing = true;
			$(this).datagrid('refreshRow', index);
		},
		onAfterEdit:function(index,row){
			row.editing = false;
			//////////////////////////
				var xx = JSON.stringify(row);
				$.post('https://localhost:5001/Okuyucu/UpdateOkuyucu',{ model:xx }
					,function(result){
						console.log(result);
					}).fail(function(e){
						console.log(e);
					}
				);
			/////////////////////////////
			$(document).ready(fun");
                WriteLiteral(@"ction () { 
			setTimeout(function () { 
				$('#grd_okyc').datagrid('reload');
			}, 1000); 
			}); 
		},
		onCancelEdit:function(index,row){
			row.editing = false;
			$(this).datagrid('refreshRow', index);
			}
		});

$('#grd_nkt').datagrid({
		//autoLoad:false,
		title:'NOKTALAR',
		iconCls:'icon-edit',
		width:700,
		height:270,
		singleSelect:true,
		idField:'id',
		//url:'https://localhost:5001/Nokta/GetNokta',
		//datasource: noktaJson;
		//method:'get',
		data: {},
		columns:[[
			{field:'sirano',title:'Sıra No',width:60,align:'center',editor:'numberbox'},
			/*{field:'grafikid',title:'Grafik ID',width:75,align:'center',editor:'numberbox'},*/
			{field:'baslamasicaklik',title:'Baş. Sıcaklık',width:110,align:'center',editor:'numberbox'},
			{field:'bitissicaklik',title:'Bit. Sıcaklık',width:110,align:'center',editor:'numberbox'},
			{field:'beklemesuresi',title:'Bekleme Süresi',width:120,align:'center',editor:'timespinner',
				formatter: function(value,row,index){
					");
                WriteLiteral(@"return value.hours + ':' + value.minutes;
				}
			},
			{field:'hizi',title:'HIZI',width:70,align:'center',editor:'numberbox'},
			{field:'arti',title:'ARTI',width:55,align:'center',editor:'numberbox'},
			{field:'eksi',title:'EKSİ',width:55,align:'center',editor:'numberbox'},
			{field:'action',title:'Action',width:110,align:'center',
				formatter:function(value,row,index){
					if (row.editing){
						var s = '<a href=""javascript:void(0)"" onclick=""saverow_nkt(this)"">Save</a> ';
						var c = '<a href=""javascript:void(0)"" onclick=""cancelrow_nkt(this)"">Cancel</a>';
						return s+c;
					} else {
						var e = '<a href=""javascript:void(0)"" onclick=""editrow_nkt(this)"">Edit</a> ';
						var d = '<a href=""javascript:void(0)"" onclick=""deleterow_nkt(this)"">Delete</a>';
						return e+d;
					}
				}
			}
		]],
		onEndEdit:function(index,row,changes){
			var ed = $(this).datagrid('getEditor', {
				index: index,
				field: 'id'
			});
			$('#grd_nkt').datagrid('reload');
			if(changes.si");
                WriteLiteral(@"rano == """" || changes.baslamasicaklik == """" || changes.bitissicaklik=="""" || changes.beklemesuresi == """" || changes.hizi=="""" || changes.arti=="""" || changes.eksi == """" ){
				alert(""Boş alanları doldurup baştan değişiklik yapınız."");
			}
			if(changes.hizi == 0)
				alert(""Hız alanı -0- olamaz."" );
		}, 
		onBeforeEdit:function(index,row){
			row.editing = true;
			$(this).datagrid('refreshRow', index);
		},
		onAfterEdit:function(index,row){
			row.editing = false;
			var asc = row.beklemesuresi;
			row.beklemesuresi = null;
			//////////////////////////
			var nn = JSON.stringify(row);
			$.post('https://localhost:5001/Nokta/UpdateNokta',{ model:nn, timespan:asc }
				,function(result){
					console.log(result);
				}).fail(function(e){
					console.log(e);
				}
			);
			$(document).ready(function () { 
			setTimeout(function () { 
			var p = row.grafikid;
			var noktaJson = $.post('https://localhost:5001/Nokta/GetNoktaById',{ grafikId:p }
				,function(result){
					$('#grd_nkt'");
                WriteLiteral(@").datagrid('loadData',result);
					
				}).fail(function(e){
					console.log(e);
				}
			);
				}, 1100); 
			}); 
			///////////////////////////// 
		}, 
		onCancelEdit:function(index,row){
			row.editing = false;
			$(this).datagrid('refreshRow', index);
		}
	});
});
function getRowIndex(target){
	var tr = $(target).closest('tr.datagrid-row');
	return parseInt(tr.attr('datagrid-row-index'));
	}
function editrow_grfk(target){
	$('#grd_grfk').datagrid('beginEdit', getRowIndex(target));
	}
function editrow_okyc(target){
	$('#grd_okyc').datagrid('beginEdit', getRowIndex(target));
	}
function editrow_nkt(target){
	$('#grd_nkt').datagrid('beginEdit', getRowIndex(target));
	}
function deleterow_grfk(target){
	$.messager.confirm('Confirm','Are you sure?',function(r){
		if (r){
			var row = $('#grd_grfk').datagrid('getSelected');
			if(row.id==null){
				$('#grd_grfk').datagrid('deleteRow', getRowIndex(target));
			}
			else{
				var xx = row.id;
				$.post('https://localhost");
                WriteLiteral(@":5001/Grafik/DeleteGrafik',{ id: xx }
					,function(result){
						console.log(result);
					}).fail(function(e){
						console.log(e);
					}
				);
			}
		$(document).ready(function () { 
			setTimeout(function () { 
				$('#grd_grfk').datagrid('reload');
			}, 1000); 
			}); 
		}
	});
	}
function deleterow_okyc(target){
	$.messager.confirm('Confirm','Are you sure?',function(r){
		if (r){
			var row = $('#grd_okyc').datagrid('getSelected');
			if(row.id==null){
				$('#grd_okyc').datagrid('deleteRow', getRowIndex(target));
			}
			else{
				var xx = row.id;
				$.post('https://localhost:5001/Okuyucu/DeleteOkuyucu',{ id: xx }
					,function(result){
						console.log(result);
					}).fail(function(e){
						console.log(e);
					}
				);
			}
		$(document).ready(function () { 
			setTimeout(function () { 
				$('#grd_okyc').datagrid('reload');
			}, 1000); 
			}); 
		}
		});
	}
function deleterow_nkt(target){
	$.messager.confirm('Confirm','Are you sure?',function(r){");
                WriteLiteral(@"
		if (r){
			var row = $('#grd_nkt').datagrid('getSelected');
			if(row.id == null){
				$('#grd_nkt').datagrid('deleteRow', getRowIndex(target));
			}
			else {
				var xx = row.id;
				$.post('https://localhost:5001/Nokta/DeleteNokta', { id: xx }
					,function(result){
						console.log(result);
					}).fail(function(e){
						console.log(e);
					}
				);
				
			}
		$(document).ready(function () { 
			setTimeout(function () { 
			var p = row.grafikid;
			var noktaJson = $.post('https://localhost:5001/Nokta/GetNoktaById',{ grafikId:p }
				,function(result){
					$('#grd_nkt').datagrid('loadData',result);
					
				}).fail(function(e){
					console.log(e);
				}
			);
				}, 1100); 
			}); 
		}
	});
	}

function saverow_grfk(target){
	
	$('#grd_grfk').datagrid('endEdit', getRowIndex(target));
	}
function saverow_okyc(target){
	$('#grd_okyc').datagrid('endEdit', getRowIndex(target));
	}
function saverow_nkt(target){
	$('#grd_nkt').datagrid('endEdit', getRowIndex(t");
                WriteLiteral(@"arget));
	}
function cancelrow_grfk(target){
	$('#grd_grfk').datagrid('cancelEdit', getRowIndex(target));
	}
function cancelrow_okyc(target){
	$('#grd_okyc').datagrid('cancelEdit', getRowIndex(target));
	}
function cancelrow_nkt(target){
	$('#grd_nkt').datagrid('cancelEdit', getRowIndex(target));
	}
function insert_grfk(){
	var row = $('#grd_grfk').datagrid('getSelected');
	if (row){
		var index = $('#grd_grfk').datagrid('getRowIndex', row);
	} else {
		index = 0;
	}
	var nr = $('#grd_grfk').datagrid('getRows');
	index = nr.length + 1;
	$('#grd_grfk').datagrid('insertRow', {
		index: index,
		row:{
			grafikadi: 'yeni grafik',
			zamanaralik: 0000,
			başlama: moment(),
		}
	});
	$('#grd_grfk').datagrid('selectRow',index);
	$('#grd_grfk').datagrid('beginEdit',index);
	}
function insert_okyc(){
	var row = $('#grd_okyc').datagrid('getSelected');
	if (row){
		var index = $('#grd_okyc').datagrid('getRowIndex', row);
	} else {
		index = 0;
	}
	var nr = $('#grd_okyc').datagrid(");
                WriteLiteral(@"'getRows');
	index = nr.length + 1;
	$('#grd_okyc').datagrid('insertRow', {
		index: index,
		row:{
			grup: 'yeni grup',
			okuyucuadi: 'yeni okuyucu',
			arti: 0,
			eksi: 0,
		}
	});
	$('#grd_okyc').datagrid('selectRow',index);
	$('#grd_okyc').datagrid('beginEdit',index);
	} 
function insert_nkt(){
	var row = $('#grd_nkt').datagrid('getSelected');
	if (row){
		var index = $('#grd_nkt').datagrid('getRowIndex', row);
	} else {
		index = 0;
	}
	var nr = $('#grd_nkt').datagrid('getRows');
	index = nr.length + 1;
	var grfk = $('#grd_grfk').datagrid('getSelected');
	$('#grd_nkt').datagrid('insertRow', {
		index: index,
		row:{
			sirano: 1,
			grafikid: grfk.id,
			baslamasicaklık: 100,
			bitissicaklık: 100,
			beklemesuresi: 0000,
			hizi: 100,
			arti: 0,
			eksi: 0,
		}
	});
	$('#grd_nkt').datagrid('selectRow',index);
	$('#grd_nkt').datagrid('beginEdit',index);
	}

	// ------------------CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART
	//");
                WriteLiteral(@" ------------------CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART
	// ------------------CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART CHART
	function draw(noktalar, okuyucular, grf_Baslama){
	//chart.destroy();
	$('#chart2').append('<canvas id=""chart1""><canvas>');
	function sort_by_key(array, key)
		{
		return array.sort(function(a, b)
			{
			var x = a[key]; var y = b[key];
			return ((x < y) ? -1 : ((x > y) ? 1 : 0));
		});
	}
	noktalar = sort_by_key(noktalar, 'sirano');
	
	function generateData() { /// okuyucular bağımsız olduğu için ataması içeride yapılıcak
			
			var unit = ""minute"";

			function unitLessThanDay() {
				return unit === 'minute';
			} 

			function beforeNineThirty(date) {
				return date.hour() < 9 || (date.hour() === 9 && date.minute() < 30);
			}

			function randomNumber(min, max) {
				return Math.random() * (max - min) + min;
			}


			/////////// değişim burday başlıyorrr 
			function randomB");
                WriteLiteral(@"ar(date, sicaklik) {  
				
				var open = randomNumber(sicaklik * 0.97, sicaklik * 1.02).toFixed(2); //toFixed sayının virgülden sonraki basamak sayısı
				return {
					t: date.valueOf(),
					y: open
				};
			}

			var date = moment(grf_Baslama); //orjinal hali ('Jan 01 1990', 'MMM DD')
			var calcTime = moment(grf_Baslama);
			var data = [];
			var lessThanDay = unitLessThanDay();
			for(i=0; i<noktalar.length; i++){
				var bas = noktalar[i].baslamasicaklik;
				var bit = noktalar[i].bitissicaklik;
				var hiz = noktalar[i].hizi;
				var bek = noktalar[i].beklemesuresi.totalMinutes;
				var a = Math.ceil( ( (60*Math.abs(bas - bit) )/hiz ) );
				calcTime = calcTime.clone().add(a, unit).startOf(unit);
				var sicaklik = Math.abs(bas - bit)/a;
				//console.log(sicaklik);
				var b = bas; 

				for (; date.isBefore(calcTime); date = date.clone().add(1, unit).startOf(unit)) {
						if(bas > bit ){
							b = b - sicaklik;
						}
						else{
							b = b + sicaklik;
						}
	");
                WriteLiteral(@"					
						data.push(randomBar(date, b));
						
				}
				if(bek>0){

					calcTime = calcTime.add(bek, unit).startOf(unit);    //aynı şekilde sağ taraf dakika olarak sağ tarafa eklenicek

					for (; date.isBefore(calcTime); date = date.clone().add(1, unit).startOf(unit)) {
						data.push(randomBar(date, bit));
					}
					
				} 
			}
			return data; 
			
		}
        /////////// değişim burda bitiyor
		
		/////////////////// okuyucu dataset

		function getRandomColor() {
			var letters = '0123456789ABCDEF'.split('');
			var color = '#';
			for (var i = 0; i < 6; i++ ) {
				color += letters[Math.floor(Math.random() * 16)];
			}
			return color;
		}

		function getxDataset(okuyucu, data)
		{
			return {
				label: okuyucu.okuyucuadi, 
				borderColor: getRandomColor(),
				backgroundColor: color(window.chartColors.white).alpha(0.5).rgbString(),
				data: data, 
				type: 'line',
				pointRadius: 0,
				fill: false,
				lineTension: 0,
				borderWidth: 2
			}
		}
                WriteLiteral(@"
		function generateDataset(){
			var t = okuyucular;
			var x = [];
			for(s=0; s<t.length;s++){
				x.push(getxDataset(t[s], generatexData(t[s])));
			}
			return x;
		}
		function generatexData(okuyucu){
			var okuyucu_data = generateData();
			var p = okuyucu.arti + okuyucu.eksi;
			
			for(i=0; i<okuyucu_data.length; i++){
				okuyucu_data[i].y = Number(okuyucu_data[i].y) + p;
			}
			return okuyucu_data;
		} 
		//console.log(""burasdasdasdasd"");
		
		//console.log(accx());
		/*function getDataset(){
			return {
				label: 'deneeme', 
				data: generateData(), 
				type: 'line',
				pointRadius: 0,
				fill: false,
				lineTension: 0,
				borderWidth: 2
			}
		}*/
		/////////////////// okuyucu dataset
		$('#chart1').remove();
		$('#graph-container').append('<canvas id=""chart1""><canvas>');
		
		var ctx = document.getElementById('chart1').getContext('2d');
		ctx.canvas.width = 900;
		ctx.canvas.height = 300;
		var now = Date();
		var m_now = moment(now).format('MMMM Do");
                WriteLiteral(@" YYYY, h:mm:ss a');
 		var color = Chart.helpers.color;
		var cfg = {
			data: {

			datasets:  generateDataset(),
			},
			options: {
				
				animation: {
					duration: 0
				},
				title: {
					display: true,
					text: m_now,
				},
				scales: {
					xAxes: [{
						type: 'time',
						distribution: 'series',
						offset: true,
						ticks: {
							major: {
								enabled: true,
								fontStyle: 'bold'
							},
							source: 'data',
							autoSkip: true,
							autoSkipPadding: 75,
							maxRotation: 0,
							sampleSize: 100
						},
						afterBuildTicks: function(scale, ticks) {
							var majorUnit = scale._majorUnit;
							var firstTick = ticks[0];
							var i, ilen, val, tick, currMajor, lastMajor;

							val = moment(ticks[0].value);
							if ((majorUnit === 'minute' && val.second() === 0)
									|| (majorUnit === 'hour' && val.minute() === 0)
									|| (majorUnit === 'day' && val.hour() === 9)
									|| (majorUnit === 'month' && val.da");
                WriteLiteral(@"te() <= 3 && val.isoWeekday() === 1)
									|| (majorUnit === 'year' && val.month() === 0)) {
								firstTick.major = true;
							} else {
								firstTick.major = false;
							}
							lastMajor = val.get(majorUnit);

							for (i = 1, ilen = ticks.length; i < ilen; i++) {
								tick = ticks[i];
								val = moment(tick.value);
								currMajor = val.get(majorUnit);
								tick.major = currMajor !== lastMajor;
								lastMajor = currMajor;
							}
							return ticks;
						}
					}],
					yAxes: [{
						gridLines: {
							drawBorder: false
						},
						scaleLabel: {
							display: true,
							labelString: 'Temperature'
						}
					}]
				},
				tooltips: {
					intersect: false,
					mode: 'index',
					callbacks: {
						label: function(tooltipItem, myData) {
							var label = myData.datasets[tooltipItem.datasetIndex].label || '';
							if (label) {
								label += ': ';
							}
							label += parseFloat(tooltipItem.value).toFixed(2);
							");
                WriteLiteral("return label;\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t};\r\n\r\n\t\t\r\n\t\tvar backgroundColor = \'white\';\r\n");
                WriteLiteral(@"		/*if(chart != undefined){
			chart.destroy();
		}	
			console.log(chart);*/
			var chart = new Chart(ctx, cfg);
			chart.update();

		document.getElementById(""download"").addEventListener('click', function(){
			
			/*Get image of canvas element*/
			var url_base64jp = chart.toBase64Image();
			/*get download button (tag: <a></a>) */
			var a =  document.getElementById(""download"");
			/*insert chart image url to download button (tag: <a></a>) */
			a.download = 'isil-islem-grafik.png';
			a.href = url_base64jp;
			a.click();
			});
		
		}
	
		</script>
	");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591