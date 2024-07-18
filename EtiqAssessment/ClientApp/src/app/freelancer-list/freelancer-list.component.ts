import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FreelancerService } from '../services/freelancer.service';
import { UpdateDialogComponent } from '../update-dialog/update-dialog.component';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { Freelancer } from '../Models/freelancer.model';

@Component({
  selector: 'app-freelancer-list',
  templateUrl: './freelancer-list.component.html',
  styleUrls: ['./freelancer-list.component.css']
})
export class FreelancerListComponent implements OnInit {
  freelancers: Freelancer[] = [];
  displayedColumns: string[] = ['username', 'mail', 'phoneNumber', 'skillsets', 'hobby', 'actions'];

  constructor(
    private freelancerService: FreelancerService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadFreelancers();
  }

  loadFreelancers(): void {
    this.freelancerService.getFreelancers().subscribe(data => {
      this.freelancers = data;
    });
  }

  openUpdateDialog(freelancer: Freelancer): void {
    const dialogRef = this.dialog.open(UpdateDialogComponent, {
      width: '400px',
      data: { ...freelancer }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result && freelancer.id !== undefined) {
        this.freelancerService.updateFreelancer(freelancer.id, result).subscribe(() => {
          this.snackBar.open('Freelancer updated successfully', 'Close', {
            duration: 3000
          });
          this.loadFreelancers();
        });
      }
    });
  }

  openDeleteDialog(freelancer: Freelancer): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: { name: freelancer.username }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result && freelancer.id !== undefined) {
        this.deleteFreelancer(freelancer.id);
      }
    });
  }

  deleteFreelancer(id: number): void {
    this.freelancerService.deleteFreelancer(id).subscribe(() => {
      this.snackBar.open('Freelancer deleted successfully', 'Close', {
        duration: 3000
      });
      this.loadFreelancers();
    });
  }
}
