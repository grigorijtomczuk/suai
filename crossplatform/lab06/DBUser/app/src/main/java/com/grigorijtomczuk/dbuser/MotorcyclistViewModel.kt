package com.grigorijtomczuk.dbuser

import android.app.Application
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.viewModelScope
import com.grigorijtomczuk.dbuser.data.AppDatabase
import com.grigorijtomczuk.dbuser.data.Motorcyclist
import com.grigorijtomczuk.dbuser.data.MotorcyclistRepository
import kotlinx.coroutines.launch

class MotorcyclistViewModel(application: Application) : AndroidViewModel(application) {

    private val repository: MotorcyclistRepository
    val allMotorcyclists: LiveData<List<Motorcyclist>>

    init {
        val motorcyclistDao = AppDatabase.getDatabase(application).motorcyclistDao()
        repository = MotorcyclistRepository(motorcyclistDao)
        allMotorcyclists = repository.allMotorcyclists
    }

    fun insert(motorcyclist: Motorcyclist) = viewModelScope.launch {
        repository.insert(motorcyclist)
    }

    fun update(motorcyclist: Motorcyclist) = viewModelScope.launch {
        repository.update(motorcyclist)
    }

    fun delete(motorcyclist: Motorcyclist) = viewModelScope.launch {
        repository.delete(motorcyclist)
    }
}
