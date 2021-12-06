import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RecipesComponent } from './recipes/recipes/recipes.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeDetailResolver } from './_resolvers/recipe-detail.resolver';


export const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'recipes', component: RecipesComponent},
      { path: 'recipes/:id', component: RecipeDetailComponent,
            resolve: {recipe: RecipeDetailResolver}}
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full'}
];
