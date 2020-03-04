setuppers['search'] = function () {
    var setupWidgetSearch = function () {
        var
            root2 = document.querySelector('[data-page="search"]'),
            searchForm = root2.querySelector('[data-widget="search_form"]'),
            EntryDate = searchForm.querySelector('[data-hook="entry_date"]'),
            LeavingDate = searchForm.querySelector('[data-hook="leaving_date"]'),
            MinimumPrice = searchForm.querySelector('[data-hook="min_price"]'),
            MaximumPrice = searchForm.querySelector('[data-hook="max_price"]'),
            AdultNumbers = searchForm.querySelector('[data-hook="numberAdults"]'),
            MinorNumbers = searchForm.querySelector('[data-hook="numberMinors"]'),
            City = searchForm.querySelector('[data-hook="city"]'),
            // Ací van la resta de camps...

            roomsList = root2.querySelector('[data-hook="rooms_list"]'),

            roomTemplate = root2.querySelector('[data-hook="room_template"]')
            ;

        var searchForm_onSubmit = function (event) {
            event.preventDefault();

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
            roomsList.innerHTML = '';

            for (var i = 0; i < rooms.length; i++) {
                addRoom(rooms[i]);
            }

            if (rooms.length == 0){
                roomsList.innerHTML = '<h1>Oops! No rooms available with your search parameters.</h1>';
            }
            roomsList.hidden = false;
        }

        var addRoom = function (room) {
            var item = document.importNode(roomTemplate.content, true);

            item.querySelector('[data-hook="room_id"]').textContent = room.id;
            item.querySelector('[data-hook="room_name"]').textContent = room.name;

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

            // Ací van la resta de camps...

            return filters;
        }

        searchForm.addEventListener('submit', searchForm_onSubmit);
    }

    // Açò ho llançareu quan feu el setupPageSearch des de
    // /Assets/page/search/js/script.js

    setupWidgetSearch();
    console.log('Search');
}