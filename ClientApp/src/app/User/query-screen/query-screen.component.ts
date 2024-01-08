import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component,OnInit, Query } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, throwError } from 'rxjs';
import { QueryService } from 'src/app/Services/query.service';
import { Recommendation } from 'src/app/models/Recommendation';
import { Data, Router } from '@angular/router';

@Component({
  selector: 'app-query-screen',
  templateUrl: './query-screen.component.html',
  styleUrls: ['./query-screen.component.css']
})
export class QueryScreenComponent {


  Data: Recommendation = {cografya:0,yerlesim:0,mimari:0,veriİletim:0};
  soruGruplari=[
{
    grupAdi: 'cografya',
    sorular: [
    {
      id:1, 
      soruMetni:'Binanın bulunduğu bölgenin arazi yoğunluğunu nasıl tanımlarsınız?',
      cevaplar: [
        {cevapMetni: 'Dağlık', puan:1},
        {cevapMetni: 'Kısmen Dağlık', puan:1.5},
        {cevapMetni: 'Dağ yok', puan:2}
      ]
    },
    {
      id:2,
      soruMetni:'Bina bir ovada mı konumlanıyor ?',
      cevaplar: [
        {cevapMetni: 'Evet', puan:1},
        {cevapMetni: 'Hayır', puan:2}
      ]
    },
    {
      id:3, 
      soruMetni:'Bina ormana yakın mı?',
      cevaplar :[
        {cevapMetni: 'Ormanın içinde', puan:1},
        {cevapMetni: 'Ormana yakın', puan:1.5},
        {cevapMetni: 'Değil', puan:2}
      ]
    },
    {
    id:4,
    soruMetni:'Binanın suya(nehir,deniz vb.) yakınlığı nedir?',
    cevaplar :[
      {cevapMetni: '1 kmden az', puan:1},
      {cevapMetni: '1-5 km arası', puan:1.5},
      {cevapMetni: 'Yakın değil', puan:2}
    ]
    },
    {
    id:5,
    soruMetni:'Binanın bulunduğu bölgede yağış miktarı nasıl ?',
    cevaplar :[
      {cevapMetni: 'Genellikle yağışlı', puan:1},
      {cevapMetni: 'Nadiren yağışlı', puan:1.5},
      {cevapMetni: 'Yağış yok', puan:2}
    ]
    }
  ]
},
{
  grupAdi:'yerlesim',
  sorular: [
    {
      id:6,
      soruMetni:'Binanın bulunduğu bölge şehir merkezinde veya kırsalda mı bulunuyor?',
      cevaplar:[
        {cevapMetni: 'Şehir merkezi', puan:1},
        {cevapMetni: 'Kırsal', puan:3},
      ]
    },
    {
      id:7,
      soruMetni:'Binanın bulunduğu bölgedeki binaların genel yüksekliği nasıl ?',
      cevaplar: [
        {cevapMetni: 'Genellikle tek katlı', puan:1},
        {cevapMetni: 'Genelde 4-5 katlı binalar', puan:2},
        {cevapMetni: 'Genelde 10 kat üzeri binalar', puan:3},
        {cevapMetni: 'Çoğunlukla Gökdelenler', puan:4}
      ]
    },
    {
      id:8, 
      soruMetni:'Binaların bulunduğu bölgedeki binaların sıklığı nasıl?',
      cevaplar: [
        {cevapMetni: 'Birbirine çok yakın', puan:1},
        {cevapMetni: 'Bölgede seyrek şekilde yerleşmiş', puan:2},
        {cevapMetni: 'Binalar arası mesafe var', puan:3}
      ]
    }
  ]
},
{
  grupAdi:'mimari',
  sorular:[
 {
  id:9,
  soruMetni:'Binanın yapı malzemesi nedir?',
  cevaplar:[
    {cevapMetni:'Çelik', puan:1},
    {cevapMetni:'Beton', puan:2},
    {cevapMetni:'Kerpiç', puan:3},
    {cevapMetni:'Ahşap', puan:4},
    {cevapMetni:'Prefabrik', puan:5}
  ]
 },
 {
id:10,
soruMetni:'Binanın cam oranı nasıl?',
cevaplar: [
  {cevapMetni:'Az', puan:1},
  {cevapMetni:'Orta', puan:2},
  {cevapMetni:'Çok', puan:3}
]
 }, 
 {
  id:11, 
  soruMetni:'Bina yalıtımı var mı?',
  cevaplar:[
    {cevapMetni:'Var', puan:1},
    {cevapMetni:'Yok', puan:2},
  ]
 },

  ]
},
{
  grupAdi: 'veriİletim',
  sorular: [
    {
      id:12,
      soruMetni:'Kullanılan sayaç tipi?',
      cevaplar: [
        {cevapMetni:'Otomatik Sayaç Okuma Sistemi', puan:1},
        {cevapMetni:'Akıllı Sayaç Sistemi', puan:10}
      ]
    }
  ]
}
  ];

cevaplar: {[key:number]:string}={};
grupPuanlari:any = {};
constructor(private queryService:QueryService, private router:Router) {}
onSubmit() {
  // Grup adları ve toplam puanları saklamak için bir dizi oluşturuldu
  let grupPuanlari: any[] = [];
  // Her bir grup için puanlama yap ve grup adıyla birlikte toplam puanı eklendi
this.soruGruplari.forEach(grup => {
  const toplamPuan = this.puanlamaYap(grup);
  this.grupPuanlari[grup.grupAdi] = toplamPuan; // Her bir grup için puanları saklandı
});


this.Data.cografya=this.grupPuanlari.cografya;
this.Data.yerlesim=this.grupPuanlari.yerlesim;
this.Data.mimari=this.grupPuanlari.mimari;
this.Data.veriİletim=this.grupPuanlari.veriİletim;
console.log(this.Data);

this.queryService.postRecommendation(this.Data).subscribe(
  (response) => {
    console.log('API Response:', response);
    // Burada API'den gelen yanıtı kullanabilirsiniz
    if(response.message=="Lan"){
      this.router.navigate(['/sonuc/lan']);
    }
    else if(response.message="Wan"){
      this.router.navigate(['sonuc/wan']);
    }
    else if(response.message="Lpwan"){
      this.router.navigate(['sonuc/lpwan']);
    }
    else if(response.message="Satellite"){
      this.router.navigate(['sonuc/satellite']);
    }

  },
  (error) => {
    console.error('API Error:', error);
    // Hata durumunda burada işlemler yapabilirsiniz
  }
);
}

puanlamaYap(grup: any): number {
  let toplamPuan = 0;

  grup.sorular.forEach((soru:any) => {
    const soruId = soru.id;
    const secilenCevap = this.cevaplar[soruId]; // Kullanıcının seçtiği cevap

    // Kullanıcı cevabı varsa puanı topla
    if (secilenCevap) {
      const puanlananCevap = soru.cevaplar.find((cevap:any) => cevap.cevapMetni === secilenCevap);
      if (puanlananCevap) {
        toplamPuan += puanlananCevap.puan;
      }
    }
  });

  console.log(`${grup.grupAdi} Toplam Puanı:`, toplamPuan);
  return toplamPuan;
}


}

