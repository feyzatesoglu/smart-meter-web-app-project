import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

constructor() { }
getLanBilgiler(): any {
  return [
    { id: 1, name: 'Mx38y Akıllı Elektrik Sayacı', description: 'Dağıtım şirketlerinin tercih ettiği bir yöntem olup, bu yöntemde enerji kesme/açma işlemleri Iskraemeco Mx38y ön ödemeli elektrik sayacı ile, sayacın yanına gitmeden uzaktan yapılabilmektedir. Faturasını ödemeyen abonenin enerjisi sistem tarafından otomatik olarak kesilmekte veya sadece buzdolabı, aydınlatma gibi araçların çalışabileceği şekilde limitlenebilmektedir.', url:"https://aktif.net/wp-content/uploads/2021/02/Akilli-Elektrik-Sayaci-Mx38y-serisi-Iskraemeco.jpg" },
    {id:2, name: 'C70 YENİ DAHİLİ HABERLEŞMELİ (MID ONAYLI) ENERJİ SAYAÇLARI', description:'Aktif ve reaktif çift yönlü MID onaylı enerji sayaçları, tek fazlı veya 3 fazlı, 3-4 telli dengesiz güç sistemlerine uygundur. Büyük boyutlu ekranı, enerji ölçümünü  ( 2 tarife)  ve ani güç değerlerinin kolay okunmasını sağlar. Buna ek olarak ekran, konfigüre edilebilir kısmi sayaçları (start/stop/reset) ve doğru faz sıralamasını gösterir.', url:'https://www.novsen.com/images/1-88827-11000101.jpg'}
  ];
}
getWanBilgiler(): any{
  return [
    { id: 1, name: 'DDZY1737 Tek Fazlı Elektrik Sayacı', description: 'DDZY1737 tek fazlı elektrik sayacı, arkadan aydınlatmalı LCD ekranlı, duvara monte tek fazlı tarife kontrollü akıllı enerji sayacıdır. Akıllı binalar, fabrikalar, okullar, hastaneler vb. yerlerde toplam çözüm için yazılım platformlu akıllı bir enerji yönetim ölçüm cihazıdır. Yerleşik kablosuz Lora iletişim modemi (GPRS/3G/4G/NB-IoT gibi daha fazla seçenek) enerjiyi toplayabilir Verileri sayaçtan alır ve enerji veri analizi için uzaktan doğrudan sunucu platformuna iletir.', url:"https://www.hoptele.com/wp-content/uploads/2023/12/smart-meter_5.jpg" },
    {id:2, name: 'Akıllı DC Elektrik Sayacı', description:'Ürün, arkadan aydınlatmalı LCD ekranlı, din raylı bir DC akıllı enerji ölçerdir. Akıllı binalar, fabrikalar, okullar, hastaneler vb. yerlerde toplam çözüm için yazılım platformlu akıllı bir enerji yönetim ölçüm cihazıdır.', url:'https://www.hoptele.com/wp-content/uploads/2023/12/dc-smart-meter_6.jpg'}
  ];
}
getLpwanBilgiler():any{
  return [
    { id: 1, name: 'DTZ1737 Üç Fazlı Enerji Sayacı', description: 'DTZ1737 üç fazlı enerji sayacı, arkadan aydınlatmalı LCD ekranlı, din raylı üç fazlı tarife kontrollü akıllı enerji ölçerdir. Akıllı binalar, fabrikalar, okullar, hastaneler vb. yerlerde toplam çözüm için yazılım platformlu akıllı bir enerji yönetim ölçüm cihazıdır. Dahili kablosuz Lora iletişim modemi (GPRS/3G/4G/NB-IoT/Modbus gibi daha fazla seçenek) toplayabilir Enerji verileri sayaçtan alınır ve enerji verileri analizi için uzaktan doğrudan sunucu platformuna iletilir.', url:"https://www.hoptele.com/wp-content/uploads/2023/11/three-phase-energy-meter.jpg" },
    {id:2, name: 'ADL200', description:'AC220V güç girişi, maksimum 10(80)A akım değeri ve RS485 ile iletişim imkanı sunan MODBUS-RTU protokolüne uyumlu özellikleri bulunan ürün, kullanıcıların parametreleri ayarlamasına olanak tanır. LCD ekranıyla kullanımı kolaydır ve kWh Sınıfı 1 standartlarına uygundur. Ayrıca, DİN 35 mm standartlarına uygun bir şekilde monte edilebilir.', url:'https://dedjh0j7jhutx.cloudfront.net/1446074178112364544%2F4ac883f2707cb102208006ed145551b9.webp'}
  ];
}
getSatelliteBilgiler():any{
  return [
  ];
}
}
