const add = require('../model/addvert');
const base64 = require('base64-js');
const path = require('path');
const fs = require('fs');
const newAddvert =async (req, res ) => {
    const{addid,addview,addclik,custid,modeladd} = req.body;
    const addvert = new add({
        addid :addid,
        addview: addview,
        addclik:addclik,
        custid:custid,
        modeladd:modeladd

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
        console.log(id);
        const result = await add.find({custid: id});
        
        
        res.json( {
            success: true,
            data:result,
            
            id : id
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

const updateAddvertW = async( req, res ) => {
    const{addid,addview,addclik,custid} =req.body;
    const id = req.params.id;
    try {
        const result = await add.findById(id);
        
        result.addid=addid;
        var num = Number(result.addview)+1;
        result.addview=num.toString();
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
const updateAddvertC = async( req, res ) => {
    const{addid,addview,addclik,custid} =req.body;
    const id = req.params.id;
    try {
        const result = await add.findById(id);
        
        result.addid=addid;
        var num = Number(result.addclik)+1;
        result.addclik=num.toString();
        result.addview=addview;
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
    //TODO
    res.json( {
        success: true,
        data: 'delete customer with id: ' + req.body.id
    })
}


const getRandomAddvert = async (req,res) => {
    
    try{
        var n = Math.floor((await add.count()) * Math.random());
        
        const result = await add.findOne().skip(n);
        const modeladd = result.modeladd;
        const decodedBytes = base64.toByteArray(modeladd);
        decodedFilePath = path.join(path.dirname("\out"), './out/decoded.prefab');
        
        fs.writeFileSync(decodedFilePath, decodedBytes);
        res.json({
            success: true,
            modeladd:result,
            

        })
        return;
    }catch(error) {
        res.json( {
            success: false,
            data :"get add error",
            error: error.message ,
        })
        return;
    }
}

const downloadAdd  = async (req,res) => {
    try{
        res.download("./out/decoded.prefab");
        return;
    }catch(error) {
        res.json( {
            success: false,
            data :"get add error",
            error: error.message ,

        })
        return;
    }
}

module.exports = { allAddvert, newAddvert, findAddvert,


    updateAddvertW, deleteAddvert,updateAddvertC ,getRandomAddvert,downloadAdd }; 

