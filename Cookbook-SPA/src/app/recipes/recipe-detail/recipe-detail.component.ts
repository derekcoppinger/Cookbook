import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { Ingredient } from '../../_models/ingredient';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../../_services/recipe.service';
import { Subscription } from 'rxjs';
import {
    FormBuilder,
    FormGroup,
    FormArray,
    FormControl,
    ValidatorFn
  } from '@angular/forms';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.scss']
})
export class RecipeDetailComponent implements OnInit {
    recipe: Recipe;
    recipeNameForm: FormGroup;
    ingredientsListForm: FormGroup;
    // ingredients: Ingredient[];
    recipeName = new FormControl('');

    ingredientsData = [
        {
            id: 1,
            name: "bread",
            checked: false
        },
        {
            id: 2,
            name: "cheese",
            checked: false
        },
    ]

  constructor(private recipeService: RecipeService, private route: ActivatedRoute) {}


  ngOnInit() {
    this.route.data.subscribe(data => {
        // this.recipe = data['recipe'];
        // this.recipe = recipe;
        this.loadRecipe(this.route.params['id']);
    });

    this.recipeNameForm = new FormGroup({
        'recipeName': new FormControl('')
    });

    this.ingredientsListForm = new FormGroup({});
  }

  loadRecipe(id: number) {
    this.recipeService.getRecipe(id).subscribe((recipe: Recipe) => {
        this.recipe = recipe;
    }, error => {
        // this.alertify.error(error);
        console.log("error loading recipes");
    });
  }

  getIngredients() {
      return [
        {
            id: 1,
            name: "bread",
            checked: false
        },
        {
            id: 2,
            name: "cheese",
            checked: false
        },
    ]
  }


  UpdateRecipeName() {
    // this.recipe.name = this.recipeName.setValue;
    // this.recipeService.updateRecipe(this.recipe.id, this.recipe);
    console.log(this.recipeNameForm);
  }

  submit() {
    // const selectedIngredientsIds = this.form.value.ingredients
    //   .map((id) => id ? this.ingredientsData[id].id : null)
    //   .filter(id => id !== null);
    // console.log(this.form.value.ingredients);
  }

}

let recipe = {
    id: 1,
    name: "Grilled Cheese",
    ingredients: [
        {
            "id": 1,
            "name": "Bread",
            "checked": true
        },
        {
            "id": 2,
            "name": "Butter",
            "checked": true
        },
        {
            "id": 3,
            "name": "Cheese",
            "checked": true
        }
    ]
}
