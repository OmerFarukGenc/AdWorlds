const add = require('../model/addvert');


const newAddvert =async (req, res ) => {
    const{addid,addview,addclik,custid} = req.body;
    const addvert = new add({
        addid :addid,
        addview: addview,
        addclik:addclik,
        custid:custid

    })
    const id =req.params.Custid
    try {
        const result = await addvert.save();
        res.json( {
            success: true,
            data: result,
            data2: req.params,
             
            data3 : `costumer id is ${id}` 
        })
    } catch (error) {
        
        console.log('new add error',error.message);
        res.json( {
            success: false,
            error: error.message 
        })
    }
    
    
}

const allAddvert = async( req, res ) => {

    try {
        const result = await add.find();
        res.json( {
            success: true,
            data: result 
        })
    } catch (error) {
        
        console.log('all add error',error.message);
        res.json( {
            success: false,
            data :"all add error",
            error: error.message 
        })
    }
    
}

const findAddvert = async( req, res ) => {
    const id = req.params.id;
    try {
        const result = await add.findById(id);
        
        
        res.json( {
            success: true,
            data:result
        })
    } catch (error) {
        
        console.log('get add error',error.message);
        res.json( {
            success: false,
            data :"get add error",
            error: error.message ,
            data : id
        })
    }
}

const updateAddvert = async( req, res ) => {
    const{addid,addview,addclik,custid} =req.body;
    const id = req.params.id;
    try {
        const result = await add.findById(id);
        
        result.addid=addid;
        result.addview=addview;
        result.addclik=addclik;
        result.custid=custid;
        result.save();
        res.json( {
            success: true,
            data: result 
        })
    } catch (error) {
        
        console.log('update add error',error.message);
        res.json( {
            success: false,
            data :"update add error",
            error: error.message 
        })
    }
    
}

const deleteAddvert = async( req, res ) => {

    res.json( {
        success: true,
        data: 'delete customer with id: ' + req.body.id
    })
}


module.exports = { allAddvert, newAddvert, findAddvert,
    updateAddvert, deleteAddvert  }; 