import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-query-screen',
  templateUrl: './query-screen.component.html',
  styleUrls: ['./query-screen.component.css']
})
export class QueryScreenComponent implements OnInit {
  form!: FormGroup;

  question1answers: string [] = ['Dağlık', 'Kısmen Dağlık', 'Dağ yok'];
  question2answers: string [] = ['Evet', 'Hayır'];
  question3answers: string [] = ['Ormanın içinde', 'Ormana yakın','Değil'];
  question4answers: string [] = ['1 kmden az', '1-5 km arası', 'Yakın değil'];
  question5answers: string[]= ['Genellikle yağışlı', 'Nadiren Yağışlı', 'Yağış yok'];
  question6answers: string[]= ['Şehir merkezi', 'Kırsal'];
  question7answers: string[]= ['Genellikle tek katlı', 'Genelde 4-5 katlı binalar', 'Genelde 10 kat üzeri binalar', 'Çoğunlukla Gökdelenler'];
  question8answers: string[]= ['Birbirine çok yakın', 'Bölgede seyrek şekilde yerleşmiş', 'Binalar arası mesafe var'];
  question9answers: string[]= ['Çelik', 'Beton', 'Kerpiç', 'Ahşap', 'Prefabrik'];
  question10answers: string[]= ['Az', 'Orta', 'Çok'];
  question11answers: string[]= ['Var', 'Yok'];
  question12answers: string[]= ['Otomatik Sayaç Okuma Sistemi', 'Akıllı Sayaç Sistemi'];


  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      // Form kontrol tanımları burada olacak
      // Örnek olarak:
      question1: ['', Validators.required],
      question2: ['', Validators.required],
      question3: ['', Validators.required],
      question4: ['', Validators.required],
      question5: ['', Validators.required],
      question6: ['', Validators.required],
      question7: ['', Validators.required],
      question8: ['', Validators.required],
      question9: ['', Validators.required],
      question10: ['', Validators.required],
      question11: ['', Validators.required],
      question12: ['', Validators.required],

    });
  }

  onSubmit() {
    // Form gönderildiğinde yapılacak işlemler
    if (this.form.valid) {
      // Form doğrulandı, verileri gönderebilirsiniz
      console.log(this.form.value);
    } else {
      // Form geçerli değil, gerekli alanları doldurun uyarısı verebilirsiniz
      // Örn: this.form.controls['question1'].markAsTouched();
    }
  }
}
