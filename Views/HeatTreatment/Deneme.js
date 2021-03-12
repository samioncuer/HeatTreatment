var calctime = grafik.baslama;
var date = grafik.baslama;

for(i=0; i<=noktalar.length; i++){
	
	calcTime += 60*(noktalar[i].baslamasicaklik - noktalar[i].bitissicaklik)/noktalar[i].hiz;   // sağ taraf dakika olarak datetime a eklenicek
                                                                                                // bi değişkende dadika hesaplatılıp sonradan eklenebilir
	for (; date.isBefore(calcTime); date = date.clone().add(1, unit).startOf(unit)) {          

		data.push(randomBar(date, noktalar[i].baslamasicaklik, noktalar[i].bitissicaklik));
	}

	if(noktalar[i].beklemesuresi.totalMinutes>0){

		calcTime += noktalar[i].beklemesuresi.totalMinutes;    //aynı şekilde sağ taraf dakika olarak sağ tarafa eklenicek

		for (; date.isBefore(calcTime); date = date.clone().add(1, unit).startOf(unit)) {

			data.push(randomConstBar(date, noktalar[i].bitissicaklik));
		}
		
	}
}

function randomBar(date, baslama, bitis){

	for(;baslama<bitis;baslama++){

		var open = randomNumber(baslama*0.95, baslama*1.05);
	}
	return {
	t: date.valueOf(),
	y: open
	};
}
function randomConstBar(date, bitis){

	var open = randomNumber(bitis*0.95, bitis*1.05);

	return {
	t: date.valueOf(),
	y: open
	};
}

