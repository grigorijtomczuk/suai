package com.grigorijtomczuk.apiuser.ui.motorcycles

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import com.grigorijtomczuk.apiuser.databinding.FragmentMotorcyclesBinding
import com.grigorijtomczuk.apiuser.viewmodel.MotorcyclesViewModel

class MotorcyclesFragment : Fragment() {

    private var _binding: FragmentMotorcyclesBinding? = null
    private val binding get() = _binding!!

    private lateinit var viewModel: MotorcyclesViewModel
    private lateinit var motorcyclesAdapter: MotorcyclesAdapter

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentMotorcyclesBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        viewModel = ViewModelProvider(this).get(MotorcyclesViewModel::class.java)

        setupRecyclerView()

        binding.searchButton.setOnClickListener {
            val make = binding.makeEditText.text.toString().trim()
            viewModel.fetchMotorcycles(make = make, model = "")
        }

        viewModel.motorcycles.observe(viewLifecycleOwner) {
            motorcyclesAdapter.updateData(it)
        }

        viewModel.isLoading.observe(viewLifecycleOwner) { isLoading ->
            binding.progressBar.visibility = if (isLoading) View.VISIBLE else View.GONE
        }

        viewModel.error.observe(viewLifecycleOwner) { error ->
            Toast.makeText(context, error, Toast.LENGTH_LONG).show()
        }
    }

    private fun setupRecyclerView() {
        motorcyclesAdapter = MotorcyclesAdapter(emptyList())
        binding.motorcyclesRecyclerView.apply {
            adapter = motorcyclesAdapter
            layoutManager = LinearLayoutManager(context)
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}