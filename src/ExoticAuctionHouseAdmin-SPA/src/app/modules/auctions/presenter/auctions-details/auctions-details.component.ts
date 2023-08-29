import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Auction } from 'src/app/shared/models/auction.model';
import { AuctionsService } from '../../services/auctions.service';
import { FormBuilder, Validators } from '@angular/forms';
import { SnackbarService } from 'src/app/shared/services/snackbar.service';

@Component({
  selector: 'app-auctions-details',
  templateUrl: './auctions-details.component.html',
  styleUrls: ['./auctions-details.component.scss']
})
export class AuctionsDetailsComponent {
  public auction: Auction | null = null;

  @Input() set _auction(value: Auction | null) {
    if (value) {
      this.auction = value;

      this.auctionForm.patchValue({
        id: this.auction.id,
        startingAmount: this.auction.startingAmount,
        currentPrice: this.auction.currentPrice,
        startDate: this.auction.startDate.toString(),
        creationDate: this.auction.creationDate.toString(),
        carId: this.auction.carId,
        location: this.auction.location,
        isEnd: this.auction.isEnd
      });
    }
  }

  auctionForm = this.fb.group({
    id: [''],
    startingAmount: [0, Validators.required],
    currentPrice: [0, Validators.required],
    startDate: ['', Validators.required],
    creationDate: ['', Validators.required],
    carId: ['', Validators.required],
    location: ['', Validators.required],
    isEnd: [true, Validators.required]
  });

  constructor(private fb: FormBuilder, private auctionService: AuctionsService, private snackbarService: SnackbarService, private router: Router) {}


  saveChanges(): void {
    let auction: Auction = {
      id: this.auctionForm.get('id')?.value!,
      startingAmount: this.auctionForm.get('startingAmount')?.value!,
      currentPrice: this.auctionForm.get('currentPrice')?.value!,
      startDate: new Date(this.auctionForm.get('startDate')?.value!),
      creationDate: new Date(this.auctionForm.get('creationDate')?.value!),
      carId: this.auctionForm.get('carId')?.value!,
      location: this.auctionForm.get('location')?.value!,
      isEnd: this.auctionForm.get('isEnd')?.value!
    };

    if (auction.id === '') {
      this.auctionService.addAuction(auction).subscribe(result => {
        this.snackbarService.alert(result, 'Auction added successfully!');
        this.router.navigate(['/auctions'])
      });
      } else {
        this.auctionService.editAuction(auction).subscribe(result => {
          this.snackbarService.alert("car added successfully", 'Auction edited successfully!');
          this.router.navigate(['/auctions'])
        });
    }
  }
}
