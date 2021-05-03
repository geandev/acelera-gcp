import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  surveyFrom: FormGroup
  nivesInteresse = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

  constructor(
    private formBuilder: FormBuilder,
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.surveyFrom = this.formBuilder.group({
      idade: [18],
      estado: ['SP'],
      areaAtuacao: ['Desenvolvimento'],
      trabalhouAzure: [false],
      trabalhouAws: [false],
      trabalhouGoogleCloud: [false],
      nivelInteresseGoogleCloud: [5],
    })
  }

  sendSurvey() {
    if (!this.surveyFrom.valid)
      return alert('Preencha todos os campos por faovr')

    this.httpClient
      .post('survey',
        {
          ...this.surveyFrom.value,
          nivelInteresseGoogleCloud: parseInt(this.surveyFrom.value.nivelInteresseGoogleCloud)
        })
      .subscribe(
        () => { alert('Obrigado, informacoes enviadas com sucesso') },
        () => { alert('Ops, Verifique os campos e  tente novamente') }
      )
  }

}
