import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent implements OnInit {
    @Input() recipe: Recipe;

    constructor() { }

    ngOnInit() {
    }

}
