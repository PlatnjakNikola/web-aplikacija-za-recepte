import { Time } from '@angular/common';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface Recipe {
  id: number,
  title: string,
  ingredients: string[],
  description: string,
  timeToPrepare: number,
  type: string,
  image: string,
  enabled: boolean
}

@Injectable({
  providedIn: 'root'
})
export class RecipesService {

  readonly APIURL = "https://localhost:7227/api";
  constructor(private http: HttpClient) { }

  //Recipes
  getRecipesList(): Observable<any[]> {
    return this.http.get<any>(this.APIURL + '/Recipes');
  }
  getRecipeById(id: number | string): Observable<any> {
    return this.http.get<any>(this.APIURL + `/Recipes/${id}`);
  }
  addRecipe(recipe: any) {
    return this.http.post(this.APIURL + '/Recipes', recipe);
  }
  updateRecipe(id: number | string, recipe: any) {
    return this.http.put(this.APIURL + `/Recipes/${id}`, recipe);
  }
  deleteRecipe(id: number | string) {
    return this.http.delete(this.APIURL + `/Recipes/${id}`);
  }
  getFilteredRecipesList(search: string): Observable<any[]> {
    /*const params = new HttpParams()
      .set('searchString', search)*/

    return this.http.get<any>(this.APIURL + `/Recipes/search/${search}`);
  }

  //USERS_______________
  getUsersList(): Observable<any[]> {
    return this.http.get<any>(this.APIURL + '/Users');
  }
  getUsersById(id: number | string): Observable<any> {
    return this.http.get<any>(this.APIURL + `/Users/${id}`);
  }
  addUser(user: any) {
    return this.http.post(this.APIURL + '/Users', user);
  }
  updaterUser(id: number | string, recipe: any) {
    return this.http.put(this.APIURL + `/Users/${id}`, recipe);
  }
  deleteUser(id: number | string) {
    return this.http.delete(this.APIURL + `/Users/${id}`);
  }
  loginUser(login: any) {
    return this.http.post(this.APIURL + '/Users/login', login);
  }

  addFavorite() {
    return this.http.post(this.APIURL + '/Favorites', {});
  }
  getFavoriteRecipes(): Observable<any[]>  {
    return this.http.get<any>(this.APIURL + '/Favorites');
  }
  removeFavorite(id: number | string) {
    return this.http.delete(this.APIURL + `/Favorites/${id}`);
  }


}
