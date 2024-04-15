# rodinbell-handhelp-xamarin
rodinbell orca50 handhelp  xamarin

## 1. init a Reader : 
        mxreaderHelper.CreateReaderHub(nameid);


## 2. connect Reader : 
        JObject jobj = new JObject
        {
            {"method", "connectDevice"},
        };
        var res = mxreaderHelper.CallReaderHubUhf(nameid, connectstr);

## 3. get firmware info :
        JObject jobj = new JObject
        {
            {"method", "getFirmwareVersion"},
        };
        var res = mxreaderHelper.CallReaderHubUhf(nameid, getfirmstr);

## 4. inventory : 
        JObject jobj = new JObject
        {
            {"method", "customInventory"},
        };
        var res = mxreaderHelper.CallReaderHubUhf(nameid, inventorystr);

## 5. close : 
        mxreaderHelper.DestroyReaderHub(nameid);




 ![image](test.png)       
