package com.grigorijtomczuk.dbuser.data

import androidx.lifecycle.LiveData
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update

@Dao
interface MotorcyclistDao {
    @Query("SELECT * FROM motorcyclists")
    fun getAll(): LiveData<List<Motorcyclist>>

    @Insert
    suspend fun insert(motorcyclist: Motorcyclist)

    @Update
    suspend fun update(motorcyclist: Motorcyclist)

    @Delete
    suspend fun delete(motorcyclist: Motorcyclist)
    
    @Query("SELECT * FROM motorcyclists WHERE id = :id")
    suspend fun getById(id: Long): Motorcyclist?
}
