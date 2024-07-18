import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { FreelancerService } from '../services/freelancer.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';

@Component({
  selector: 'app-freelancer-form',
  templateUrl: './freelancer-form.component.html',
  styleUrls: ['./freelancer-form.component.css']
})
export class FreelancerFormComponent implements OnInit {
  freelancerForm: FormGroup;
  freelancerId: any;

  constructor(
    private fb: FormBuilder,
    private freelancerService: FreelancerService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.freelancerForm = this.fb.group({
      username: ['', Validators.required],
      mail: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      skillsets: ['', Validators.required],
      hobby: [''],
    });
  }

  ngOnInit(): void {
    this.freelancerId = this.route.snapshot.params['id'];
    if (this.freelancerId) {
      this.freelancerService.getFreelancer(this.freelancerId).subscribe(data => {
        this.freelancerForm.patchValue(data);
      });
    }
  }

  onSubmit(): void {
    if (this.freelancerForm.valid) {
      if (this.freelancerId) {
        this.freelancerService.updateFreelancer(this.freelancerId, this.freelancerForm.value).subscribe(() => {
          this.snackBar.open('Freelancer updated successfully', 'Close', {
            duration: 3000
          });
          this.router.navigate(['/']);
        });
      } else {
        this.freelancerService.createFreelancer(this.freelancerForm.value).subscribe(() => {
          this.snackBar.open('Freelancer created successfully', 'Close', {
            duration: 3000
          });
          this.router.navigate(['/']);
        });
      }
    }
  }

  openUpdateDialog(): void {
    const dialogRef = this.dialog.open(UpdateDialogComponent, {
      width: '400px',
      data: this.freelancerForm.value
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.freelancerService.updateFreelancer(this.freelancerId, result).subscribe(() => {
          this.snackBar.open('Freelancer updated successfully', 'Close', {
            duration: 3000
          });
          this.router.navigate(['/']);
        });
      }
    });
  }

  openDeleteDialog(): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: { name: this.freelancerForm.value.username }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteFreelancer();
      }
    });
  }

  deleteFreelancer(): void {
    if (this.freelancerId) {
      this.freelancerService.deleteFreelancer(this.freelancerId).subscribe(() => {
        this.snackBar.open('Freelancer deleted successfully', 'Close', {
          duration: 3000
        });
        this.router.navigate(['/']);
      });
    }
  }
}
