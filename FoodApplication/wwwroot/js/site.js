// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let apiURL = "https://forkify-api.herokuapp.com/api/v2/recipes";
let apikey = "b355aa15-1579-4aa5-b235-03b426292f03";

async function GetRecipies(recipeName,id,isAllShow) {
    let resp = await fetch(`${apiURL}?search=${recipeName}&key=${apikey}`);
    let result = await resp.json();
    console.log(result)
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(1, 7);
    showRecipes(Recipes, id)
}

function showRecipes(recipes, id) {
    $.ajax({
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        type: 'POST',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function(htmlResult) {
            $('#' + id).html(htmlResult);
            getAddedCarts();
        }
    })
}


async function getOrderRecipe(id, showId) {
    let resp = await fetch(`${apiURL}/${id}?key=${apikey}`);
    let result = await resp.json();
    let recipe = result.data.recipe;
    showOrderRecipeDetails(recipe, showId);

} 
function showOrderRecipeDetails(orderRecipeDetails, showId) {
    $.ajax({
        url: '/Recipe/ShowOrder',
        data: orderRecipeDetails,
        dataType: 'html',
        type: 'POST',
        success: function (htmlResult) {
            $('#' + showId).html(htmlResult);
        }
    });
}

//order page


function quantity(option) {
    let qty = $('#qty').val();
    let price = parseInt($('#price').val());
    let totalAmount = 0;
    if (option === 'inc') {
        qty = parseInt(qty)+1;
    }
    else {
        qty = qty == 1 ? qty : qty - 1;
        
    }
    totalAmount = price * qty
    $('#qty').val(qty);
    $('#price').val(totalAmount)
}


async function cart() {
    let iTag = $(this).children('i')[0];
    let recipeId = $(this).attr('data-recipeId')
    if ($(iTag).hasClass('fa-regular')) {
        let resp = await fetch(`${apiURL}/${recipeId}?key=${apikey}`);
        let result = await resp.json();
        let cart = result.data.recipe;
        cart.recipeId = recipeId;
        delete cart.id;
        cartRequest(cart, 'SaveCart', 'fa-solid', 'fa-regular', iTag);

    } else {
        let data = { Id: recipeId }; 
        cartRequest(data, 'RemoveCartFromList', 'fa-regular', 'fa-solid', iTag);
    }
}


function cartRequest(data, action,addcls,removecls,iTag) {
    $.ajax({
        url: '/Cart/' + action,
        type: 'POST',
        data: data,
        success: function (resp) {
            $(iTag).addClass(addcls);
            $(iTag).removeClass(removecls)
        },
        error: function (err) {
            console.log(err)
        }
    })

}


function getAddedCarts() {
    $.ajax({
        url: '/Cart/GetAddedCarts',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('.AddToCartIcon').each((index, spanTag) => {
                let recipeId = $(spanTag).attr("data-recipeId");
                for (var i = 0; i < result.length; i++) { 
                    if (recipeId == result[i]) {
                        let itag = $(spanTag).children('i')[0];
                        $(itag).addClass('fa-solid');
                        $(itag).removeClass('fa-regular');
                        break;
                    }
                }

            }
            )
        },
        error: function (err) {
            console.log(err)
        }
    })
}



function getCartList() {
    $.ajax({
        url: '/Cart/GetCartList',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('#showCartList').html(result);
        },
        error: function (err) {
            console.log(err);
        }
    });
}