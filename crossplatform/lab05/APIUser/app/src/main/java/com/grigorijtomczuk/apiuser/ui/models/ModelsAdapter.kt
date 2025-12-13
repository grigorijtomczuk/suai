package com.grigorijtomczuk.apiuser.ui.models

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.apiuser.api.Motorcycle
import com.grigorijtomczuk.apiuser.databinding.MotorcycleItemBinding

class ModelsAdapter(private var motorcycles: List<Motorcycle>) :
    RecyclerView.Adapter<ModelsAdapter.MotorcycleViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MotorcycleViewHolder {
        val binding =
            MotorcycleItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return MotorcycleViewHolder(binding)
    }

    override fun onBindViewHolder(holder: MotorcycleViewHolder, position: Int) {
        val motorcycle = motorcycles[position]
        holder.bind(motorcycle)
    }

    override fun getItemCount() = motorcycles.size

    fun updateData(motorcycles: List<Motorcycle>) {
        this.motorcycles = motorcycles
        notifyDataSetChanged()
    }

    class MotorcycleViewHolder(private val binding: MotorcycleItemBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun bind(motorcycle: Motorcycle) {
            binding.motorcycleMakeModel.text = "${motorcycle.make} ${motorcycle.model}"
            binding.motorcycleYearType.text = "${motorcycle.year} - ${motorcycle.type}"
            binding.motorcyclePower.text = motorcycle.power
        }
    }
}