import { Component } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css'],
})
export class AdminPageComponent {
  users: User[] = [];

  constructor(
    private accountService: AccountService,
    private alertify: AlertifyService
  ) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.accountService.getUsers().subscribe(
      (data) => {
        this.users = data;
        console.log('Users: ', this.users);
      },
      (error) => {
        this.alertify.error('Error fetching users: ' + error);
      }
    );
  }

  deleteUser(userId: number): void {
    this.accountService.deleteUser(userId).subscribe(
      () => {
        // Remove the deleted user from the list
        this.users = this.users.filter((user) => user.id !== userId);
        this.alertify.success('User deleted successfully');
        // Veriyi yeniden çek
        this.loadUsers();
      },
      (error) => {
        this.alertify.error('Error deleting user: ' + error);
      }
    );
  }

  filterUsers(type: string): void {
    this.accountService.getUsersByType(type).subscribe(
      (data: User[]) => {
        if (data && data.length > 0) {
          this.users = data;
        } else {
          // Hizmet çağrısından gelen veri boşsa veya yoksa bir mesaj gösterebilirsiniz.
          // Örnek olarak:
          console.log('Belirtilen tipte kullanıcı bulunamadı.');
          this.users = []; // Kullanıcı listesini boşaltabilirsiniz veya mevcut içeriği koruyabilirsiniz.
        }
      },
      (error) => {
        this.users = [];
        console.error('Türdeki kullanıcıları getirirken hata oluştu: ', error);
      }
    );
  }
}
