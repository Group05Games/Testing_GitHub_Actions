using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet {

	private int[] wallet;
	private int walletTier;
	private int walletMax;
	private int tierStep = 25;

	public Wallet() {
		this.wallet = new int[sizeof(ResourceTypes.Resource)];
		this.walletTier = 1;
		this.walletMax = getWalletMax(walletTier);
	}
	
	public Wallet(int[] wallet, int walletTier) {
		this.wallet = wallet;
		this.walletTier = walletTier;
		this.walletMax = getWalletMax(walletTier);
	}

	public ResourceTypes.Resource getResourceType(ResourceTypes.Resource type) {
		return type;
	}

	public void addResource(ResourceTypes.Resource type, int amount) {
		this.wallet[(int)type] += amount;
		validateWallet(type);
	}

	public void addResource(ResourceTypes.Resource type) {
		this.wallet[(int)type] += Random.Range(1, 8);
		validateWallet(type);
	}

	public void loseResource(ResourceTypes.Resource type) {
		this.wallet[(int)type] -= Random.Range(1, 8);
		validateWallet(type);
	}

	public void clearResource(ResourceTypes.Resource type) {
		this.wallet[(int)type] = 0;
	}

	public int getResource(ResourceTypes.Resource type) {
		//Debug.Log(getResourceType(type) + " " + this.wallet[(int)type]);
		return this.wallet[(int)type];
	}

	public void setResource(ResourceTypes.Resource type, int value) {
		this.wallet[(int)type] = value;
	}

	public void validateWallet(ResourceTypes.Resource type) {
		int resourceHeldCount = getResource(type);
		int walletMaxCap = getWalletMax(this.getWalletTier());
		if (resourceHeldCount < 0) { //Negative resources in wallet. Set to 0.
			clearResource(type);
		}
		else if (resourceHeldCount > walletMaxCap) { //Wallet beyond full. Set to max.
			setResource(type, walletMaxCap);
		}
	}

	public int getWalletMax(int walletTier) {
		return walletTier * this.tierStep;
	}
	public int getWalletTier() {
		return this.walletTier;
	}
	public void increaseWalletTier() {
		this.walletTier += 1;
	}
}
