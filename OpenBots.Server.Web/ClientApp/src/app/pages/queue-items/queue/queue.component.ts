import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from '../../../@core/services/http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-queue',
  templateUrl: './queue.component.html',
  styleUrls: ['./queue.component.scss'],
})
export class QueueComponent implements OnInit {
  queueForm: FormGroup;
  isSubmitted = false;

  constructor(
    private fb: FormBuilder,
    private httpService: HttpService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.queueForm = this.initializeQueueForm();
  }

  get formControls() {
    return this.queueForm.controls;
  }
  initializeQueueForm() {
    return this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      maxRetryCount: [null, [Validators.pattern(/^-?([0-9]|[0-9][0-9]d*)?$/)]],
      description: [''],
    });
  }

  addQueue(): void {
    this.isSubmitted = true;
    this.httpService
      .post('Queues', this.queueForm.value, { observe: 'response' })
      .subscribe(
        (response) => {
          if (response && response.status == 201) {
            this.isSubmitted = false;
            this.httpService.success('New Queue has created');
            this.router.navigate(['pages/queueitems']);
            this.queueForm.reset();
          }
        },
        () => (this.isSubmitted = false)
      );
  }
}
