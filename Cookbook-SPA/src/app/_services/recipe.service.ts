import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from '../_models/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getRecipes(): Observable<Recipe[]> {
        return this.http.get<Recipe[]>(this.baseUrl + 'recipes');
    }

    getRecipe(id): Observable<Recipe> { // Change this back to return type Observable<Recipe>
        return this.http.get<Recipe>(this.baseUrl + 'recipes/' + id);
    }

    updateRecipe(id: number, recipe: Recipe) {
        return this.http.put(this.baseUrl + 'recipes/' + id, recipe);
    }

    deleteDelete(id: number) {
        return this.http.delete(this.baseUrl + 'recipes/' + id);
    }



}
