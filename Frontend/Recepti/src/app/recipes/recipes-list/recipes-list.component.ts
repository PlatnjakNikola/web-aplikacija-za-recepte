import { Component, OnInit, ViewChild, ElementRef, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, map, forkJoin, BehaviorSubject } from 'rxjs';
import { Recipe, RecipesService } from 'src/app/services/recipes.service';
import { Router } from '@angular/router';
import { share, tap, finalize } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth.service'
import { LoginRegisterComponent } from 'src/app/account/login-register/login-register.component';
import { AddEditRecipeComponent } from 'src/app/recipes/add-edit-recipe/add-edit-recipe.component';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent implements OnInit {
  recipesList$!: Observable<any[]>;
  recipesListNoFilter$!: Observable<any[]>;
  recipes: any[] = [];
  admin: boolean = false;
  add: boolean = false;
  login: boolean = false;
  id: number = 0;
  noRecipe: boolean = false;
  username: string = "";
  showFavorite: boolean = false;
  favoritesList$!: Observable<any[]>;
  recipeToDelete!: any;

  //Filtering
  recipesFilter: any = [];
  search: string = '';
  //typeFilter: string = '';
  filtered: boolean = false;
  recipe!: Recipe;

  @ViewChild('loginModalCloseButton') loginModalCloseButton!: ElementRef;
  @ViewChild('deleteModalCloseButton') deleteConfirmationModal!: ElementRef;
  @ViewChild('loginModal') loginModal!: ElementRef;
  @ViewChild(LoginRegisterComponent) appLogin!: LoginRegisterComponent;
  @ViewChild(AddEditRecipeComponent) addEditRecipe!: AddEditRecipeComponent;

  constructor(private service: RecipesService, private http: HttpClient, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.recipesList$ = this.service.getRecipesList();
    this.recipesListNoFilter$ = this.service.getRecipesList();
    if (this.authService.isLoggedIn()) {
      var user = this.authService.getUserData();
      this.id = user.id;
      this.username = user.username;
      this.login = true;
      this.admin = user.isAdmin;
    }
  }


  modalClose() {
    this.recipesList$ = this.service.getRecipesList();
    this.addEditRecipe.resetData();
  }
  addRecipe() {
    this.add = true;
    this.recipe = {
      id: 0,
      title: "",
      ingredients: [],
      description: "",
      timeToPrepare: 0,
      type: "",
      image: "",
      enabled: false
    }
  }

  showRecipe(recipeId:number|string) {
    this.router.navigate(['/recipe', recipeId]);
    //this.router.navigate(['/recipe', this.admin, recipeId]);
  }
  openLoginModal() {
    document.getElementById('staticBackdrop2')?.classList.add('show');
  }

  deleteRecipe() {
    this.service.deleteRecipe(this.recipeToDelete.id).subscribe(() => {
      this.recipesList$ = this.service.getRecipesList();
    },
      (error: any) => {
        alert(error.error);
      });
    this.deleteConfirmationModal.nativeElement.click();

  }

  searchRecipe() {
    this.recipesListNoFilter$ = this.recipesList$.pipe(share());
    console.log("Search:" + this.search);
    //this.recipesList$ = this.service.getFilteredRecipesList(this.search);
    this.service.getFilteredRecipesList(this.search).subscribe(
      (recipes: any) => {
        this.recipesList$ = of(recipes);
      },
      (error: any) => {
        if (error.status === 404) {
          this.noRecipe = true;
          this.recipesList$ = of([]);
        }
        else
          console.error(error);
      }
    );
  }

  home() {
    this.recipesList$ = this.service.getRecipesList();
    this.search = "";
    this.showFavorite = false;
    this.noRecipe = false;
  }

  onLoginSuccess(recipe: any) {
    this.authService.login(recipe);
    this.loginModalCloseButton.nativeElement.click();
    this.id = recipe.id;
    this.username = recipe.username;
    this.admin = recipe.isAdmin;
    this.login = true;
  }

  logOut() {
    this.authService.logout();
    this.id = 0;
    this.username = "";
    this.admin = false;
    this.login = false;
    this.home();
  }

  async showFavorites() {
    this.showFavorite = true;

    this.service.getFavoriteRecipes().subscribe(
      (response) => {
        console.log(response);

        if (response.length === 0) {
          this.noRecipe = true;
          this.recipesList$ = of([]);
        }
        else { 
          const requests = response.map(favorite => this.service.getRecipeById(favorite.recipeId));
          forkJoin(requests).subscribe(
            (recipes) => {
              this.recipesList$ = of(recipes);
            }
            );
        }
      }
    );
  }

  setRecipeToDelete(recipe:any) {
    this.recipeToDelete = recipe;
  }

  closeModal() {
    this.appLogin.resetData();
  }

  @HostListener('window:beforeunload', ['$event'])
  unloadHandler(event:any) {
    this.authService.logout();
  }
}
