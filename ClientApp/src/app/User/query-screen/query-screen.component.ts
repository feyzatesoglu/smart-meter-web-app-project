import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-query-screen',
  templateUrl: './query-screen.component.html',
  styleUrls: ['./query-screen.component.css']
})
export class QueryScreenComponent implements OnInit {
  form!: FormGroup;

  question1answers: string [] = ['Zorlu', 'Basit'];
  question2answers: string [] = ['Kentsel', 'Kırsal'];
  question3answers: string [] = ['Zorlu', 'Basit'];
  question4answers: string [] = ['Sürekli', 'Aralıklı'];

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      // Form kontrol tanımları burada olacak
      // Örnek olarak:
      question1: ['', Validators.required],
      question2: ['', Validators.required],
      question3: ['', Validators.required],
      question4: ['', Validators.required],
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
