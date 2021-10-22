var start = true;

function getUrl(menuList, menuStr) {

    if (start) {
        for (var i = 0; i < menuList.length; i++) {
            if (menuList[i].menu_name == menuStr) {
                start = false;
                console.log(handUrl(menuList[i]))
                return handUrl(menuList[i])
            } else {
                if (menuList[i].children != undefined && start) {
                    getUrl(menuList[i].children, menuStr);
                }

            }
        }
    }
};

function handUrl(menu) {
    var axiosUrls = {
        get: "123",
        update: "123",
        del: "123",
        add: "123",
    };
    const myMenu = menu.children;
    myMenu.forEach(item => {
        const myName = item.mould.mould_name;
        const myUrl = item.mould.url;

        switch (myName) {
            case 'get':
                axiosUrls.get = myUrl;
                break;
            case 'update':
                axiosUrls.update = myUrl;
                break;
            case 'del':
                axiosUrls.del = myUrl;
                break;
            case 'add':
                axiosUrls.add = myUrl;
                break;
        }
    });
    return axiosUrls;
}

export {
    getUrl,
    handUrl
}