setuppers['search'] = function () {
    var widget = document.querySelector('[data-widget="search_form"]');
    widget.addEventListener("submit", function validarDatos(event) {
        event.preventDefault();
        if (validateEntryDate(widget.querySelector('[data-hook="entry_date"]').value)
            || validateLeavingDate(widget.querySelector('[data-hook="entry_date"]').value, widget.querySelector('[data-hook="leaving_date"]').value)
            || validateMinPrice(parseFloat(widget.querySelector('[data-hook="min_price"]').value))
            || validateMaxPrice(parseFloat(widget.querySelector('[data-hook="max_price"]').value), parseFloat(widget.querySelector('[data-hook="min_price"]').value))
            || validateNumberAdults(parseInt(widget.querySelector('[data-hook="numberAdults"]').value))
            || validateNumberMinors(parseInt(widget.querySelector('[data-hook="numberMinors"]').value))
            || validateCity(widget.querySelector('[data-hook="city"]').value)) {
            return;
        }
        setupWidgetSearch();
    });

    var setupWidgetSearch = function () {
        var
            searchPage = document.querySelector('[data-page="search"]'),
            searchForm = searchPage.querySelector('[data-widget="search_form"]'),
            EntryDate = searchForm.querySelector('[data-hook="entry_date"]'),
            LeavingDate = searchForm.querySelector('[data-hook="leaving_date"]'),
            MinimumPrice = searchForm.querySelector('[data-hook="min_price"]'),
            MaximumPrice = searchForm.querySelector('[data-hook="max_price"]'),
            AdultNumbers = searchForm.querySelector('[data-hook="numberAdults"]'),
            MinorNumbers = searchForm.querySelector('[data-hook="numberMinors"]'),
            City = searchForm.querySelector('[data-hook="city"]'),

            containerRoomsList = searchPage.querySelector('[data-hook="rooms_list"]'),
            containerRoomsListController = searchPage.querySelector('[data-hook="rooms_list_controller"]'),
            roomsList = document.createElement("ul"),

            roomTemplate = searchPage.querySelector('[data-hook="room_template"]')
            ;

        var searchForm_onSubmit = function (event) {
            var searcher = buildSearcher();

            searcher.search(
                buildFilters()
            );
        }

        var buildSearcher = function () {
            var searcher = new Searcher();

            searcher.setSuccessCallback(updateRoomsList);

            return searcher;
        }

        var updateRoomsList = function (rooms) {
            containerRoomsList.innerHTML = '<h2>Results</h2>';
            roomsList.className = "rooms_list";
            containerRoomsList.appendChild(roomsList);
            if (rooms.length == 0) {
                containerRoomsList.innerHTML = '<p>We are sorry! No rooms available with your search parameters.</p>';
            }

            for (var i = 0; i < rooms.length; i++) {
                addRoom(rooms[i]);
            }

            containerRoomsListController.hidden = true;
            containerRoomsList.hidden = false;
        }

        var addRoom = function (room) {
            var item = document.importNode(roomTemplate.content, true);
            item.querySelector('[data-hook="room_name"]').textContent = room.name;
            item.querySelector('[data-hook="room_link"]').href = location.href + "/" + room.slug;
            item.querySelector('[data-hook="room_image"]').srcset = room.image;
            item.querySelector('[data-hook="room_small_image"]').src = room.smallImage;
            item.querySelector('[data-hook="room_small_image"]').alt = "Image of " + room.name;

            roomsList.appendChild(item);
        }

        var buildFilters = function () {
            var filters = new Filters();

            if (EntryDate.value != '') {
                filters.setEntryDate(
                    EntryDate.value
                );
            }
            if (LeavingDate.value != '') {
                filters.setLeavingDate(
                    LeavingDate.value
                );
            }
            if (AdultNumbers.value != '') {
                filters.setAdultNumbers(
                    AdultNumbers.value
                );
            }
            if (MinorNumbers.value != '') {
                filters.setMinorNumbers(
                    MinorNumbers.value
                );
            }
            if (MinimumPrice.value != '') {
                filters.setMinimumPrice(
                    MinimumPrice.value
                );
            }
            if (MaximumPrice.value != '') {
                filters.setMaximumPrice(
                    MaximumPrice.value
                );
            }
            if (City.value != '') {
                filters.setCity(
                    City.value
                );
            }

            return filters;
        }

        searchForm_onSubmit();
    }

    console.log('Search');
}