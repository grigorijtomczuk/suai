package com.grigorijtomczuk.apiuser.ui.manufacturers

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.apiuser.api.Motorcycle
import com.grigorijtomczuk.apiuser.databinding.ManufacturerItemBinding

class ManufacturersAdapter(private var motorcycles: List<Motorcycle>) :
    RecyclerView.Adapter<ManufacturersAdapter.ManufacturerViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ManufacturerViewHolder {
        val binding =
            ManufacturerItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ManufacturerViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ManufacturerViewHolder, position: Int) {
        val manufacturer = motorcycles[position]
        holder.bind(manufacturer)
    }

    override fun getItemCount() = motorcycles.size

    fun updateData(motorcycles: List<Motorcycle>) {
        this.motorcycles = motorcycles
        notifyDataSetChanged()
    }

    class ManufacturerViewHolder(private val binding: ManufacturerItemBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun bind(motorcycle: Motorcycle) {
            binding.manufacturerName.text = motorcycle.name
            binding.manufacturerCountry.text = motorcycle.id.toString()
        }
    }
}