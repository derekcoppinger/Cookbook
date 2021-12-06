import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../../_services/recipe.service';


@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {
   recipes: Recipe[];

  constructor(private recipeService: RecipeService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
        // this.recipes = data['recipes'];
        this.loadRecipes();
    });
  }

  loadRecipes() {
        this.recipeService.getRecipes().subscribe((recipes: Recipe[]) => {
            this.recipes = recipes;
        }, error => {
            // this.alertify.error(error);
            console.log("error loading recipes");
        });
    }

}


let recipes = [
    {
        "id": 1,
        "name": "Grilled Cheese",
        "ingredients": [
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

    },
    {
        "id": 2,
        "name": "Pasta Salad",
        "ingredients": [
            {
                "id": 1,
                "name": "Chilled Pasta",
                "checked": false
            },
            {
                "id": 2,
                "name": "Vinegar",
                "checked": false
            },
            {
                "id": 3,
                "name": "Oil",
                "checked": true
            }
        ]

    }
]
