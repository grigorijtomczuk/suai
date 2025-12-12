package com.grigorijtomczuk.apiuser.viewmodel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.grigorijtomczuk.apiuser.api.ApiClient
import com.grigorijtomczuk.apiuser.api.Manufacturer
import kotlinx.coroutines.launch
import java.util.logging.Logger

class ManufacturersViewModel : ViewModel() {

    private val _manufacturers = MutableLiveData<List<Manufacturer>>()
    val manufacturers: LiveData<List<Manufacturer>> = _manufacturers

    private val _isLoading = MutableLiveData<Boolean>()
    val isLoading: LiveData<Boolean> = _isLoading

    private val _error = MutableLiveData<String>()
    val error: LiveData<String> = _error

    fun fetchManufacturers() {
        viewModelScope.launch {
            _isLoading.value = true
            try {
                val response = ApiClient.instance.getManufacturers()
                if (response.isSuccessful && response.body() != null) {
                    _manufacturers.value = response.body()!!.results
                } else {
                    _error.value = "Failed to load manufacturers"
                    Logger.getLogger("Failed to load manufacturers")
                }
            } catch (e: Exception) {
                _error.value = "No internet connection"
            }
            _isLoading.value = false
        }
    }
}